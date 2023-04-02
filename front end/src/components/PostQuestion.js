import React, { useState, useEffect } from 'react';
import axios from 'axios';
import DropdownList from "react-widgets/DropdownList";
import QuestionList from './QuestionList.js';

const PostQuestion = () => {
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const [course, setCourse] = useState([]);
    const [allCourses, setAllCourses] = useState([]);
    const [keyword, setKeyword] = useState('');

    const [isAdding, setIsAdding] = useState(false);
    const [questions, setQuestions] = useState([]);
    const [questionIds, setQuestionIds] = useState([]);
    const [questionId, setQuestionId] = useState([]);
    const [hits, setHits] = useState([]);
    const [foundHits, setFoundHits] = useState(false);
    const [intervalId, setIntervalId] = useState(0);

    useEffect(() => {
        refreshQList();
    }, []);

    useEffect(() => {
        refreshCourseList();
    }, []);


    const refreshQList = () => {
        axios.get('https://localhost:8080/Question/getall')
            .then(res => {
                console.log(res);
                const questions = res.data;
                setQuestions(questions);
            }).catch((err) => {
                console.log(err.message);
            })
    }

    const refreshCourseList = () => {
        axios.get('https://localhost:8080/Course/getall')
            .then(res => {
                console.log(res);
                setAllCourses(res.data);
            }).catch((err) => {
                console.log(err.message);
            })
    }

    const queryByQId = (id) => {
        axios.get('https://localhost:8080/Query/question/' + id)
            .then(res => {
                console.log(res.data);
            }).catch(err => {
                console.log(err.message);
            })
    }

    const getQuestionIds = () => {
        const ids = questions.map((question) => { return question.question_id; });
        return ids;
    }

    const handleSubmit = event => {
        event.preventDefault();

        const question = {
            "title": title,
            "content": content,
            "keywords": keyword,
            "courses": course
        };

        setIsAdding(true);

        axios.post('https://localhost:8080/Question/add', question)
            .then(res => {
                console.log(res.data);
                refreshQList();
                refreshCourseList();
                setIsAdding(false);
                setTitle('');
                setKeyword('');
                setCourse([]);
                setContent('');
            }).catch(err => {
                console.log(err.message);
            })
    }

    const handleQueryAll = () => {
        if (intervalId) {
            document.getElementById("qAll").innerHTML = "Query All";
            clearInterval(intervalId);
            setIntervalId(0);
        }
        else {
            let qIds = getQuestionIds();
            console.log(qIds);
            document.getElementById("qAll").innerHTML = "Stop Query";
            for (let id of qIds) {
                queryByQId(id);
            }

            const newIntervalId = setInterval(() => {
                qIds.forEach((id) => {
                    queryByQId(id);
                })
            }, 300000);
            setIntervalId(newIntervalId);
            setQuestionIds(qIds);
        }
        
    }

    const showHitList = (e) => {
        setQuestionId(e.target.value);
        axios.get('https://localhost:8080/Hit/getbyquestionid/' + e.target.value)
            .then(res => {
                console.log(res);
                setHits(res.data);
                setFoundHits(true);
            }).catch((err) => {
                console.log(err.message);
            })
    }

    const handleQuery = (id) => {
        if (intervalId) {
            document.getElementById(id).innerHTML = "Query";
            clearInterval(intervalId);
            setIntervalId(0);
        }
        else {
            document.getElementById(id).innerHTML = "Stop Query";
            queryByQId(id);
            const newIntervalId = setInterval(() => {
                queryByQId(id);
            }, 300000);
            setIntervalId(newIntervalId);
        }
    }

    const handleDelete = (id) => {
        axios.post('https://localhost:8080/Question/delete?question_id=' + id)
            .then(res => {
                console.log(res.data);
                refreshQList();
            })
    }

    const handleCreate = (newCourse) => {
        setCourse([newCourse]);
    }

    return (
        <div id="home" className="container-fluid home" style={{ padding: "150px 40px" }}>
            <div id="tool" className="container-fluid tool" style={{ padding: "100px 40px" }}>
                <h1>Use Snitch 9000</h1>
                <div className="container-fluid">
                    <div className="row">
                        <div className="col-sm-6">
                            <p>
                                <span className="badge bg-danger">{hits.length}</span>
                                &nbsp;Instances found!
                                <label for="hit-list"></label>
                                <select id="hit-list" value={questionId} onChange={showHitList}>
                                    <option>Select hits by Question Id</option>
                                    {questionIds.map((id) => (
                                        <option value={id}>{id}</option>
                                    ))}
                                </select>
                            </p>
                            <ul className="list-group" style={{ padding: "0px 0px", overflow: "scroll", height: "150px", width: "100%" }}>
                                {!foundHits && <li className="list-group-item">first item</li>}
                                {!foundHits && <li className="list-group-item">second item</li>}
                                {!foundHits && <li className="list-group-item">third item</li>}
                                {!foundHits && <li className="list-group-item">fourth item</li>}
                                {foundHits && hits.map((hit) => (
                                    <li className="list-group-item"><a href={hit.link} target="_blank">{hit.link}</a></li>
                                ))}
                            </ul>
                        </div>
                        <div className="col-sm-6">
                            <form onSubmit={handleSubmit}>
                                <div className="mb-3 mt-3">
                                    <label for="input">Enter question information here:</label>
                                </div>
                                <div class="form-group">
                                    <label for="usr">Title:</label>
                                    <input type="text" required name="title" value={title} class="form-control" id="usr" onChange={(e) => setTitle(e.target.value)} />
                                </div>
                                <div class="form-group">
                                    <label for="keywords">Keyword:</label>
                                    <input type="text" required name="keywords" value={keyword} class="form-control" id="keywords" autoComplete="off" onChange={(e) => setKeyword(e.target.value)} />
                                </div>
                                <div class="form-group">
                                    <label for="sel1">Course Select</label>
                                    <DropdownList
                                        filter
                                        containerClassName="form-control"
                                        allowCreate="onFilter"
                                        onCreate={handleCreate}
                                        onChange={course => setCourse([course])}
                                        value={course}
                                        data={allCourses}
                                    />
                                </div>
                                <div class="form-group">
                                    <label for="pwd">Content:</label>
                                    <textarea type="text" required name="content" value={content} class="form-control" id="pwd" onChange={(e) => setContent(e.target.value)} />
                                </div>

                                <br></br>
                                {!isAdding && <button type="submit" className="btn btn-primary">Add Question</button>}
                                {isAdding && <button type="submit" className="btn btn-primary">Adding Question...</button>}
                            </form>
                        </div>
                    </div>
                    <br></br>
                    <QuestionList questions={questions} handleDelete={handleDelete} handleQuery={handleQuery} />
                    <br></br>
                    <button id="qAll" className="btn btn-primary" onClick={() => handleQueryAll()} >Query All</button>
                </div>
            </div>
        </div>
    );
}
export default PostQuestion;
