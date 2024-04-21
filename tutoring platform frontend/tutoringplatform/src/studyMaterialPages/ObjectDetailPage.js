// ObjectDetailPage.js
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import StudyMaterialService from '../services/StudyMaterialService';
import { Typography } from '@material-ui/core';

const ObjectDetailPage = () => {
    const { id } = useParams();
    const [object, setObject] = useState(null);

    useEffect(() => {
        const fetchObject = async () => {
            try {
                const response = await StudyMaterialService.get(id);
                setObject(response.data);
            } catch (error) {
                console.error('Error fetching object:', error);
            }
        };

        fetchObject();
    }, [id]);

    if (!object) {
        return <Typography>Loading...</Typography>;
    }

    return (
        <div>
            <Typography variant="h5">{object.Title}</Typography>
            <Typography>Education Level: {object.EducationLevel}</Typography>
            {/* Render content preview here */}
        </div>
    );
};

export default ObjectDetailPage;
