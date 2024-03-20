import api from './http-common';
import jwtDecode from "jwt-decode";

const login = (user) => {
    return api.post(`/auth/login`, user)
        .then((response) => {
            if(response.data.accessToken){
                localStorage.setItem("user", JSON.stringify(response.data));
            }
            return response.data;
        });
};

const logout = () => {
    localStorage.removeItem("user");
}

const register = (data) =>{
    return api.post(`/auth/register`, data);
}

const getCurrentUser = () => {
    return JSON.parse(localStorage.getItem('user'));
}

const getId = () => {
    const token = localStorage.getItem("user");
    if(token) {
        var user;
        user = jwtDecode(token);
        console.log(user);
    }else {
        user = {
            userId: "Null",
        };
    }
    return user.userId;
}

const AuthenticationService = {
    login,
    logout,
    register,
    getCurrentUser,
    getId
};

export default AuthenticationService;