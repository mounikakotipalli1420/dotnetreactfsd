import React, { useState } from 'react';
import axios from 'axios';
import './Survey.css';

function GetAllSurveys() {
  const [surveys, setSurveys] = useState([]);
  const [error, setError] = useState('');

  const getAllSurveys = async () => { debugger
    try {
      console.log('Fetching surveys...');
      const response = await axios.get('http://localhost:5095/api/Survey');
      console.log('Fetched surveys:', response.data);
      setSurveys(response.data);
    } catch (error) {
      console.error('Error fetching surveys:', error);
      setError('Error fetching surveys. Please try again.');
    }
  };
  

  return (
    <div className="container">
      <h2>All Surveys</h2>
      {error && <div className="error">{error}</div>}
      {Array.isArray(surveys) && surveys.length > 0 ? (
        <ul>
          {surveys.map((survey) => (
            <li key={survey.id}>
              <strong>{survey.title}</strong>
              <p>Created on: {new Date(survey.createdAt).toLocaleDateString()}</p>
              <p>Number of Questions: {survey.questions.length}</p>
              <p>Author: {survey.author}</p>
              {/* Add more survey details or actions as needed */}
            </li>
          ))}
        </ul>
      ) : (
        <p>customer survey.</p>
      )}

      <button onClick={getAllSurveys}>Load Surveys</button>
    </div>
  );
}

export default GetAllSurveys;