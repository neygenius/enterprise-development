import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';

const SubjectCreate = () => {
    const [name, setName] = useState('');
    const [year, setYear] = useState('');
    const [message, setMessage] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.post('/subject', { name, year });
            setMessage('Subject created successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error creating subject:', error);
            setMessage(`Failed to create subject: ${error.response?.data || error.message}`);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Create subject</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
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
                    />
                </div>
                <button type="submit" className="btn btn-primary">Create</button>
            </form>
        </div>
    );
}

export default SubjectCreate;