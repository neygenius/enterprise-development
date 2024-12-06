import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api/api';

const SubjectUpdate = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [name, setName] = useState('');
    const [year, setYear] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchSubject = async () => {
            try {
                const response = await api.get(`/subject/${id}`);
                setName(response.data.name);
                setYear(response.data.year);
            } catch (error) {
                console.error('Error fetching subject:', error);
                setError('Subject not found');
            }
        };

        fetchSubject();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.put(`/subject/${id}`, { name, year });
            setMessage('Subject updated successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error updating subject:', error);
            setMessage('Failed to update subject.');
        }
    };

    return (
        <div className="container mt-5">
            <h2>Update Subject</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            {error && (
                <div className="alert alert-danger" role="alert">
                    {error}
                </div>
            )}
            {!error && (
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label htmlFor="name" className="form-label">Name:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="name"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label htmlFor="year" className="form-label">Year:</label>
                        <input
                            type="text"
                            className="form-control"
                            id="year"
                            value={year}
                            onChange={(e) => setYear(e.target.value)}
                            required
                            pattern="\d{4}-\d{4}"
                        />
                    </div>
                    <button type="submit" className="btn btn-primary">Update Subject</button>
                </form>
            )}
        </div>
    );
};

export default SubjectUpdate;