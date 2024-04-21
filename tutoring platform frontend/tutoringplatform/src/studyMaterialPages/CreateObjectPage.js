// CreateObjectPage.js
import React, { useState } from 'react';
import StudyMaterialService from '../services/StudyMaterialService';
import { useHistory } from 'react-router-dom';
import { Button, TextField, Typography } from '@material-ui/core';

const CreateObjectPage = () => {
    const [formData, setFormData] = useState({
        Title: '',
        EducationLevel: '',
        // Add other fields here
    });

    const history = useHistory();

    const handleChange = e => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value,
        }));
    };

    const handleSubmit = async e => {
        e.preventDefault();
        try {
            await StudyMaterialService.create(formData);
            history.push('/all'); // Redirect to all objects page after successful creation
        } catch (error) {
            console.error('Error creating object:', error);
            // Handle error here
        }
    };

    return (
        <div>
            <Typography variant="h4">Create Object</Typography>
            <form onSubmit={handleSubmit}>
                <TextField
                    name="Title"
                    label="Title"
                    value={formData.Title}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                <TextField
                    name="EducationLevel"
                    label="Education Level"
                    value={formData.EducationLevel}
                    onChange={handleChange}
                    fullWidth
                    required
                />
                {/* Add other fields here */}
                <Button type="submit" variant="contained" color="primary">
                    Create
                </Button>
            </form>
        </div>
    );
};

export default CreateObjectPage;
