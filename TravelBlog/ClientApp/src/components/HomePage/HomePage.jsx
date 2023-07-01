import React, { useState, useRef, useEffect } from 'react';
import { Navbar, NavLink, NavItem } from 'reactstrap'; 
import { Link } from 'react-router-dom';    
import "./HomePage.css";

const HomePage = () => {
    const [data, setData] = useState([]); 


    useEffect(() => {
        fetch(`home`)  
        .then((res) => {
            return res.json(); 
        })
        .then((data) => {
            setData(data); 
        });  
    }, []); 

    const articleSummaries = data.map((summary) => {

        return (
            <li>
                <div>
                    <span>{summary.title}</span>
                    <span>{summary.country}</span>
                    <span>{summary.publishDate}</span>
                    <p>{summary.introduction}</p>
                </div>
                <img src={summary.image} /> 
            </li>
        )
    }); 

    return (
        <div> 
            <span>Japan</span>
            <ul>{articleSummaries}</ul>
        </div>
    )
}

export default HomePage; 