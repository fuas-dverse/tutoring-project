import {useEffect, useState} from "react";
import StudyMaterialService from "../services/StudyMaterialService";
import "./Card.css";
import axios from "axios";
import {useNavigate} from "react-router-dom";

function Card() {
    const [event, setEvent] = useState([]);
    let navigate=useNavigate();

    useEffect(() => {
        StudyMaterialService.getAll().then((response) => {
            setEvent(response.data.events)
            console.log(response.data.events);
        }).catch(error => {
            console.log(error);
        })

    }, []);

    const LoadEdit = (itemName) => {
        navigate(`/studymaterial/${itemName}`);
    }

    return (
        // <div className="wrapperCards">
        <div className="card-box">
            {event.map((item) => {
                    return(
                        <div className="card2">
                            <img src={require('../assets/background_2.jpg')}alt={'image for study materials'} className="card__img" />
                            <div className="card__body">
                                <h2 className="card__title">{item.title}</h2>
                                <p className="card__description">{item.educationLevel}</p>
                                <h3 className="card__price">Topic</h3>
                                <button onClick={() => {
                                    LoadEdit(item.name)
                                }} className="card__btn">View</button>
                            </div>
                        </div>
                    )
                }
            )
            }

        </div>
        // </div>

    )

}

export default Card;