import React, { Component, useState } from 'react';


//Loads text from a txt file. Filename input as props. 
//Street view and regular Google Maps api 
//users can pin the article to their list. 
//Flights API
//Title
//History 
//Transportation & Tips 
//Photo Album 
//export pdf
//Json object : ID, Title, Array of json files 
//Sub component location : ID, Title, google map coords, text body  . Prefecture / Region above city 

const Article = (props) => {   
    const [data, setData] = useState(null); 
    const sectionRefs = useRef([]); 

    const scrollToSection = (placeId) => {
        sectionRefs.current[placeId]?.scrollIntoView({behavior: "instant", block: "start"}); 
    }

    useEffect(() => {
        fetch(`articles/${props.articleId}`)
        .then((res) => res.json())
        .then((data) => {
            setData(data); 
            data.sections.forEach((section) => {
                sectionRefs.push(section.placeId); 
            })
        }); 
    }, []); 

    
    const sideBarItems = data.sections.map((section, index) => {
        return(
            <li key={index}>
                <input type="button" onClick={() => scrollToSection(section.placeId)}>{section.subtitle}</input>
            </li>
        )
    });

    //compose paragraphs into sections and sections into article
    const sections = data.sections.map((section) => {
        const paragraphs = section.paragraphs.map((paragraph, index) => {
            const item = paragraph.contains("src=") ? <p>{paragraph}</p> : <img src={paragraph.replace("src=", "")}></img>; 
            return (<li key={index}>{item} </li>); 
        }); 

        return(<li key={section.placeId} ref={section.placeId}> 
            <h2>{section.subtitle}</h2>
            {/**Google Maps Embed */}
            <ul>{paragraphs}</ul> 
        </li>); 
    });
    
    return (
        <div className="article">
            <div className="main-article">
                <h1>{data.title}</h1>
                <i>Last Visited `${data.publishDate}`</i>
                <p>{data.introduction}</p>
                <div>{/**Google maps routes embed */}</div>
                <ul>{sections}</ul>
            </div>
            <div>
                <h3>{data.region}</h3>
                <ul>
                    {sideBarItems}
                </ul>
            </div>
        </div>
    );
}