import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';
import SubjectDelete from './SubjectDelete';

const SubjectList = () => {
    const [subjects, setSubjects] = useState([]);
    const [message, setMessage] = useState('');
    
    const handleDeleteSuccess = (id) => {
        setSubjects(subjects.filter((subject) => subject.id !== id));
    };

    useEffect(() => {
        const fetchSubjects = async () => {
            try {
                const response = await api.get('/subject');
                setSubjects(response.data);
            } catch (error) {
                console.error('Error fetching subjects:', error);
                setMessage('Failed to fetch subjects.');
                setTimeout(() => setMessage(''), 3000);
            }
        };
        fetchSubjects();
    }, []);

    return (
        <div className="container mt-5">
            <h2>Subject List</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <Link to="/subject/create" className="btn btn-success mb-3">Create New Subject</Link>
            <ul className="list-group">
                {subjects.length > 0 ? (
                    subjects.map((subject) => (
                        <li key={subject.id} className="list-group-item d-flex justify-content-between align-items-center">
                            <div>
                                <p><strong>Name:</strong> {subject.name}</p>
                                <p><strong>Year:</strong> {subject.year}</p>
                            </div>
                            <div>
                                <Link to={`/subject/update/${subject.id}`} className="btn btn-warning btn-sm me-2">Update</Link>
                                <SubjectDelete id={subject.id} onDeleteSuccess={handleDeleteSuccess} />
                            </div>
                        </li>
                    ))
                ) : (
                    <li className="list-group-item">No subjects found</li>
                )}
            </ul>
        </div>
    );
}

export default SubjectList;