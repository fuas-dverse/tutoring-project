// AllObjectsPage.js
import React, { useState, useEffect } from 'react';
import StudyMaterialService from '../services/StudyMaterialService';
import { Card, CardContent, Typography, Grid } from '@material-ui/core';

const AllObjectsPage = () => {
    const [objects, setObjects] = useState([]);

    useEffect(() => {
        const fetchObjects = async () => {
            try {
                const response = await StudyMaterialService.getAll();
                setObjects(response.data);
            } catch (error) {
                console.error('Error fetching objects:', error);
            }
        };

        fetchObjects();
    }, []);

    return (
        <Grid container spacing={2}>
            {objects.map(object => (
                <Grid item xs={12} sm={6} md={4} key={object._id}>
                    <Card>
                        <CardContent>
                            <Typography variant="h5" component="h2">
                                {object.Title}
                            </Typography>
                            <Typography color="textSecondary">
                                Education Level: {object.EducationLevel}
                            </Typography>
                        </CardContent>
                    </Card>
                </Grid>
            ))}
        </Grid>
    );
};

export default AllObjectsPage;
