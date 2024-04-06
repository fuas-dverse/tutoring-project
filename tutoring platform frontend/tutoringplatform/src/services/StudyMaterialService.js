import http from "./http-common";

const get = id => {
    return http.get(`/studyMaterials/${id}`);
};

const getStudyMaterials = tutorId => {
    return http.get(`/studyMaterials/${tutorId}`)
}
const getAll = () => {
    return http.get(`/studyMaterials`);
};


const StudyMaterialService = {
    get,
    getStudyMaterials,
    getAll,
};
export default StudyMaterialService;
