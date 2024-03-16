import axios from 'axios'

const USER_BASE_REST_API_URL = 'http://localhost:7259/auth/users';
const USER_BASE_REST_API_URL_POST = 'http://localhost:7259/auth/register'


class UserService{

    getAllUsers(){
        return axios.get(USER_BASE_REST_API_URL)
    }

    createUser(){
        return axios.post(USER_BASE_REST_API_URL_POST)
    }


}

export default new UserService();