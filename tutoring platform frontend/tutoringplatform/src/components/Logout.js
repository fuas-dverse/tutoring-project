import {Navigate} from "react-router-dom";

function Logout() {
    const user = {
        accessToken: "",
        role: "",
    };

    localStorage.setItem("user", JSON.stringify(user));
    return <Navigate to="/home" />;
}

export default Logout;