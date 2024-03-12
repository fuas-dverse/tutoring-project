import {Component, useState} from "react";
import axios from "axios";
import {Link, useNavigate} from "react-router-dom";
import StudyMaterialService from "../services/StudyMaterialService";
import AuthenticationService from "../services/AuthenticationService";
const url = 'http://localhost:7259/api/all'; //to be checked


const StudyMaterialForm = () => {

    let tutorId = AuthenticationService.getId();

    const navigate = useNavigate();
    const [title, setTitle] = useState('');
    const [educationLevel, setEducationLevel] = useState('');
    const [tags, setTags] = useState('');
    const [content, setContent] = useState('');



    const onSubmit = async (e) => {
        e.preventDefault();
        try {
            const resp = await axios.post(url, { title: title, educationLevel:educationLevel,
                tags: tags, content: content, tutorId: tutorId});
            console.log(resp.data);
            navigate("/studymaterials");
        } catch (error) {
            console.log(error.response);
        }
    };
    return (

        <form id="uploadForm" className={"create_form"} onSubmit={(e) => onSubmit(e)}>
            <div className="wrapper_createStudyMaterial">
                <header id={"titleBIG"}>Upload content! </header>
                <div>
                    <label id={"category"}>Title</label>
                    <input
                        data-cy="title"
                        id="title"
                        type={"text"}
                        value={title}
                        placeholder="Enter the title"
                        name="title"
                        onChange={(e) => setTitle(e.target.value)}
                    />
                </div>
                <div>
                    <label id={"category"}>Education Level</label>
                    <textarea value={educationLevel}
                              data-cy="educationLeve;"
                              id="educationLevel"
                              placeholder="Enter the education level"
                              name="educationLevel"
                              onChange={(e) => setEducationLevel(e.target.value)}></textarea>
                </div>
                <div>
                    <label id={"category"}>Tags</label>
                    <textarea value={tags}
                              data-cy="tags"
                              placeholder="Add some tags"
                              id="tags"
                              name="tags"
                        // onChange={(e) => onInputChange(e)}>
                              onChange={(e) => setTags(e.target.value)}>

                                </textarea>
                </div>

                <div>
                    <label id={"date"}>Content</label>
                    <input type={"text"}
                           data-cy="content"
                           value={content}
                           id="date"
                           placeholder="Upload (pdf/video/png)"
                           name="content"
                        // onChange={(e) => onInputChange(e)}
                           onChange={(e) => setContent(e.target.value)}
                    />
                </div>
                <button type="submit" id={"postBtn"}>Submit</button>
            </div>
        </form>
    );
}

export default StudyMaterialForm;