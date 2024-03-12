import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:7259/",
    headers: {
        "Content-type": "application/json"
    }
});