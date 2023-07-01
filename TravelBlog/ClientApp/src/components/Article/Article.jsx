import React, { useState, useRef, useEffect } from 'react';
import "./Article.css"; 

const Article = (props) => {   
    const [data, setData] = useState(null); 
    const [focusSection, setFocusSection] = useState(null); 
    const [loading, setLoading] = useState(true); 
    const sectionRefs = useRef([]); 
    const scrollLock = useRef(false); 
    const scrollLockId = useRef(0); 

    const scrollToSection = (index) => {
        //TODO: Use scrollEnd once it's on most browsers. 
        clearTimeout(scrollLockId.current); 
        scrollLock.current = true; 
        setFocusSection(index); 
        sectionRefs.current[index]?.scrollIntoView({behavior: "instant", block: "start"}); 
        scrollLockId.current = setTimeout(() => {scrollLock.current = false}, sectionRefs.current.length * 150); 
    };

    const onScroll = () => {
        if(!scrollLock.current) {
            let min = Number.MAX_VALUE; 
            let topIndex = 0; 
            for(let i = 0; i < sectionRefs.current.length; i++) {
                let top = sectionRefs.current[i].getBoundingClientRect().top; 
                if(top <= min && top >= 0) {
                    min = top;
                    topIndex = i; 
                }
            }
            setFocusSection(topIndex); 
        }
    };

    useEffect(() => {
        fetch(`article/${props.articleId}`)
        .then((res) => {
            return res.json(); 
        })
        .then((data) => {
            setData(data); 
            setFocusSection(0); 
            setLoading(false); 
            window.removeEventListener('scroll', onScroll);
            window.addEventListener('scroll', onScroll, { passive: true});
        });  
    }, []); 

    
    const sideBarItems = loading? [] : data.sections.map((section, index) => {
        return(
            <li key={index} className='section-ref-container'>
                <button className={index === focusSection ? "section-ref-item selected" : "section-ref-item"} onClick={() => scrollToSection(index)}>{section.subtitle}</button>
            </li>
        )
    });

    //compose paragraphs into sections and sections into article
    const sections = loading? [] : data.sections.map((section) => {
        const paragraphs = section.paragraphs.map((paragraph, index) => {
            const item = !paragraph.includes("src=") ? <p>{paragraph}</p> : <img src={paragraph.replace("src=", "")} alt="Missing Image"></img>; 
            return (<li key={index}>{item} </li>); 
        }); 

        return(<li key={section.placeId} ref={ref => {
            if(sectionRefs.current.length < data.sections.length) {
                sectionRefs.current.push(ref);
            }}}> 
            <span className="section-title">{section.subtitle}</span>
            <hr></hr>
            {/**Google Maps Embed */}
            <ul className='paragraph-list'>{paragraphs}</ul> 
        </li>); 
    });
    
    return (
        loading? null : <div className="article">
            <img src="/Onomichi-Dock.jpg" className="title-container"/>
            <div className="article-container">
                <div className="main-article">
                    <span className="title">{data.title}</span>
                    <i>Last Visited `${data.publishDate}`</i>
                    <p>{data.introduction}</p>
                    <div>{/**Google maps routes embed */}</div>
                    <ul className="section-list">{sections}</ul>
                </div>
                <div className="side-bar-menu">
                    <h4>{data.title}</h4>
                    <ul className="side-bar-items-list">
                        {sideBarItems}
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default Article; 