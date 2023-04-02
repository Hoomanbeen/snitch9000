const QuestionList = (props) => {
    const questions = props.questions;

    return (
        <div>
            <h2>All questions:</h2>
            <div className="question-list">
                <table>
                    <thead>
                        <tr>
                            <th>Question Id</th>
                            <th>Title</th>
                            <th>Course</th>
                            <th>Content</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {questions.map((question) => (
                            <tr>
                                <td>{question.question_id}</td>
                                <td>{question.title}</td>
                                <td>{question.courses}</td>
                                <td>{question.content}</td>
                                <td onClick={() => props.handleDelete(question.question_id)}><button className="btn btn-primary">delete</button></td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}
export default QuestionList;