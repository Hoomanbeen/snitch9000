import './App.css';
import 'bootstrap/dist/css/bootstrap.css';
import "react-widgets/styles.css";
import { BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Navigation from './components/navigation';
import Home from './components/home';
import Tool from './components/tool';
import GetQuestions from './components/GetQuestions.js';
import PostQuestion from './components/PostQuestion.js';
import Login from './components/Login';
import Register from './components/Register';

function App() {
  return (
    <Router>
      <Navigation />
      <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/tool" element={<PostQuestion />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} />
          </Routes>
      </Router>
  );
}

export default App;
