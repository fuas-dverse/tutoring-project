import axios from "axios";

export default axios.create({
    baseURL: "http://api-gateway:7041/",
    headers: {
        "Content-type": "application/json"
    }
});