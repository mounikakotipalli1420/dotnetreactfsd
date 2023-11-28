import React, { useState } from "react";
import axios from "axios";
import "./Survey.css";

function CreateSurvey() {
  const initialQuestion = {
    text: "",
    type: "RatingScale",
    answers: [{ text: "" }],
  };

  const [title, setTitle] = useState("Customer Satisfaction Survey");
  const [questions, setQuestions] = useState([initialQuestion]);
  const [error, setError] = useState("");

  const addQuestion = () => {
    setQuestions([...questions, { ...initialQuestion }]);
  };

  const handleQuestionChange = (index, field, value) => {
    const updatedQuestions = [...questions];
    updatedQuestions[index] = { ...updatedQuestions[index], [field]: value };
    setQuestions(updatedQuestions);
  };

  const handleAnswerChange = (questionIndex, answerIndex, value) => {
    const updatedQuestions = [...questions];
    updatedQuestions[questionIndex].answers[answerIndex].text = value;
    setQuestions(updatedQuestions);
  };

  const addAnswer = (questionIndex) => {
    const updatedQuestions = [...questions];
    updatedQuestions[questionIndex].answers.push({ text: "" });
    setQuestions(updatedQuestions);
  };

  const removeAnswer = (questionIndex, answerIndex) => {
    const updatedQuestions = [...questions];
    updatedQuestions[questionIndex].answers.splice(answerIndex, 1);
    setQuestions(updatedQuestions);
  };

  const removeQuestion = (index) => {
    const updatedQuestions = [...questions];
    updatedQuestions.splice(index, 1);
    setQuestions(updatedQuestions);
  };

  const createSurvey = async () => {
    try {
      const response = await axios.post("http://localhost:5095/api/Survey", {
        title: title,
        questions: questions.map((q) => ({
          text: q.text,
          type: q.type,
          answers: q.answers.map((a) => ({ text: a.text })),
        })),
      });

      console.log(response.data);
      // Handle success, redirect, show a success message, etc.
    } catch (error) {
      console.error(error);
      setError("Error creating survey. Please try again.");
    }
  };

  return (
    <div className="container">
      <h2>Create Survey</h2>
      {error && <div className="error">{error}</div>}
      <label>Title:</label>
      <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />

      <div>
        <label>Questions:</label>
        {questions.map((q, questionIndex) => (
          <div key={questionIndex} className="question-container">
            <input
              type="text"
              placeholder="Enter your question"
              value={q.text}
              onChange={(e) => handleQuestionChange(questionIndex, "text", e.target.value)}
            />
            {q.answers.map((a, answerIndex) => (
              <div key={answerIndex} className="answer-container">
                <input
                  type="text"
                  placeholder={'Enter answer ${answerIndex + 1}'}
                  value={a.text}
                  onChange={(e) => handleAnswerChange(questionIndex, answerIndex, e.target.value)}
                />
                <button type="button" onClick={() => removeAnswer(questionIndex, answerIndex)}>
                  Remove Answer
                </button>
              </div>
            ))}
            <button type="button" onClick={() => addAnswer(questionIndex)} className="add-btn">
              Add Answer
            </button>
            <button type="button" onClick={() => removeQuestion(questionIndex)} className="remove-btn">
              Remove Question
            </button>
          </div>
        ))}
        <button type="button" onClick={addQuestion} className="add-btn">
          Add Question
        </button>
      </div>

      <button className="create-survey-btn" onClick={createSurvey}>
        Create Survey
      </button>
    </div>
  );
}

export default CreateSurvey;