import React from 'react';
import axios from 'axios';

class GetQuestions extends React.Component {
    state = {
        questions: []
    }

    componentDidMount() {
        axios.get(`https://localhost:8080/Question/getall`)
            .then(res => {
                const questions = res.data;
                this.setState({ questions });
            })
    }

    render() {
        return (
            <ul>
                {
                    this.state.questions
                        .map(question =>
                            <li key={question.question_id}>{question.question_id} {question.title} {question.content} {question.keywords }</li>
                        )
                }
            </ul>
        );
    }
}
export default GetQuestions;
