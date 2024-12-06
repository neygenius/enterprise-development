import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import SubjectCreate from './components/SubjectCreate';
import SubjectDelete from './components/SubjectDelete';
import SubjectList from './components/SubjectList';
import SubjectUpdate from './components/SubjectUpdate';


function App() {
    return (
        <Router>
            <div>
                <h1 className="text-center">Subject Client</h1>
                <Routes>
                    <Route path="/" element={<SubjectList />} />
                    <Route path="/subject/create" element={<SubjectCreate />} />
                    <Route path="/subject/update/:id" element={<SubjectUpdate />} />
                    <Route path="/subject/delete/:id" element={<SubjectDelete />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
