import http from "./http-common";

const get = id => {
    return http.get(`/studymaterials/${id}`);
};

const getStudyMaterials = tutorId => {
    return http.get(`/studymaterials/${tutorId}`)
}
const getAll = () => {
    return http.get(`/studymaterials`);
};


const StudyMaterialService = {
    get,
    getStudyMaterials,
    getAll,
};
export default StudyMaterialService;
