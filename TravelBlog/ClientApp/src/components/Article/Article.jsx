import React, { useState, useRef, useEffect } from 'react';
import "./Article.css"; 

const Article = (props) => {   
    const [data, setData] = useState(null); 
    const [focusSection, setFocusSection] = useState(-1); 
    const [loading, setLoading] = useState(true); 
      
    const paragraphRefs = useRef([]); 
    const overviewRef = useRef(); 
    const remarksRef = useRef(); 
    const snapshotsRef = useRef(); 
    const blockScrollEvent = useRef(false); 
    const scrollLockId = useRef(0); 

    const overviewIndex = -1;
    const remarksIndex = loading ? -2 : data.paragraphs.length; 
    const snapshotsIndex = loading ? -3 : data.paragraphs.length + 1; 

    const scrollToSection = (index) => { 
        console.log(index); 
        clearTimeout(scrollLockId.current); 
        blockScrollEvent.current = true; 
        setFocusSection(index);
        if(index === overviewIndex) {
            overviewRef.current.scrollIntoView({behavior: "instant", block: "start"});
        }
        else if(index === remarksIndex) {
            remarksRef.current.scrollIntoView({behavior: "instant", block: "start"});
        } 
        else if(index === snapshotsIndex) {
            snapshotsRef.current.scrollIntoView({behavior: "instant", block: "start"});
        }
        else {
            paragraphRefs.current[index]?.scrollIntoView({behavior: "instant", block: "start"});
        }
        scrollLockId.current = setTimeout(() => {blockScrollEvent.current = false}, Math.abs(focusSection - index) * 200); 
    };

    const onScroll = () => {
        if(!blockScrollEvent.current) {
            if(overviewRef.current.getBoundingClientRect().top >= 0) {
                setFocusSection(overviewIndex);
                return; 
            }
            for(let i = 0; i < paragraphRefs.current.length; i++) {
                let top = paragraphRefs.current[i].getBoundingClientRect().top; 
                if(top >= 0) {
                    setFocusSection(i); 
                    return;  
                }
            }
            if(remarksRef.current.getBoundingClientRect().top >= 0) {
                setFocusSection(remarksIndex); 
                return; 
            }
            setFocusSection(snapshotsIndex);
        }
    };

    useEffect(() => {
        fetch(`article/${props.articleId}`)
        .then((res) => {
            return res.json(); 
        })
        .then((data) => {
            setData(data);    
            window.removeEventListener('scroll', onScroll);
            window.addEventListener('scroll', onScroll, { passive: true});
            setLoading(false);
        });  
    }, [props.articleId]); 

    
    const hasSubTitles = loading? [] : data.paragraphs.filter(paragraph => paragraph.subTitle.length > 0);  
    const subTitleRefs = loading? [] : hasSubTitles.map((hasSubTitle, index) => {
        return(
            <li key={hasSubTitle.id} className='section-ref-container'>
                <button className={index === focusSection ? "section-ref-item selected" : "section-ref-item"} onClick={() => scrollToSection(index)}>{hasSubTitle.subTitle}</button>
            </li>
        )
    });

    const paragraphs = loading ? [] : data.paragraphs.map((paragraph) => {
        let refIndex = hasSubTitles.map(hasSubTitle => hasSubTitle.id).indexOf(paragraph.id); 
        return(
            <li key={paragraph.id} ref={ref => {
                if(refIndex !== -1) {
                    paragraphRefs.current[refIndex] = ref;
                }}}> 
                {paragraph.subTitle.length > 0 && <span className='subtitle'>{paragraph.subTitle}</span>}
                <p>{paragraph.text}</p>
            </li>
        )
    });

    return (
        loading? null : <div className="article">
            <div className='header-container'>
                <img src={`/${data.coverImage}`} className="header-image"/>
                <span className='title-asia'>しまなみ海道</span>
            </div>
            <div className="article-container">
                <div className="main-article">
                    <span className='publish-date'>Last Visited {data.publishDate.substring(0, 10)}</span>
                    <div ref={ref => overviewRef.current = ref}>
                        <span className='subtitle'>Overview</span>
                        <p>{data.introduction}</p> 
                    </div>
                    <ul className="section-list">{paragraphs}</ul>
                    <span className='subtitle' ref={ref => remarksRef.current = ref}>Remarks</span>
                    <span className='subtitle' ref={ref => snapshotsRef.current = ref}>Snapshots</span>
                    {/**Remarks and Images section here */}
                </div>
                <div className="side-bar-menu">
                    <h4>{data.title}</h4>
                    <ul className="side-bar-items-list">
                        <li className='section-ref-container'>
                            <button className={overviewIndex === focusSection ? "section-ref-item selected" : "section-ref-item"} onClick={() => scrollToSection(overviewIndex)}>Overview</button>
                        </li>
                        {subTitleRefs}
                        <li className='section-ref-container'>
                            <button className={remarksIndex === focusSection ? "section-ref-item selected" : "section-ref-item"} onClick={() => scrollToSection(remarksIndex)}>Remarks</button>
                        </li>
                        <li className='section-ref-container'>
                            <button className={snapshotsIndex === focusSection ? "section-ref-item selected" : "section-ref-item"} onClick={() => scrollToSection(snapshotsIndex)}>Snapshots</button>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default Article; 