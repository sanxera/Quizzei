import request from '../utils/request';

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function getReport(params) {
  console.log("🚀  ~ file: report.js:7 ~ getReport ~ params:", params)
  if (isEnvironmentDevelopment) return {
    "quizUuid": "0f9eec9c-ec41-4f42-94e3-01a700506d6b",
    "quizDescription": " Mauris blandit laoreet leo, eget tempus nisi dictum id. Nulla facilisi. Nam vitae iaculis est. Nam quis eleifend diam",
    "totalCompletedQuiz": 6,
    "totalNotCompletedQuiz": 3,
    "totalQuestions": 2,
    "questions": [
      {
        "questionUuid": "1a0f3bba-b978-4b3d-f20c-08dacc9b0e99",
        "description": "Questão 1",
        "totalAnswers": 8,
        "totalHitPercentage": 87,
        "options": [
          {
            "optionUuid": "3b9c9d44-d4c1-45f3-133a-08dacc9b0e9b",
            "description": "Opção 1",
            "isCorrect": true,
            "totalOptionAnswers": 6,
            "hitQuantity": 6,
            "hitPercentage": 100
          },
          {
            "optionUuid": "8b1204ea-6677-447f-133b-08dacc9b0e9b",
            "description": "Opção 2",
            "isCorrect": true,
            "totalOptionAnswers": 1,
            "hitQuantity": 1,
            "hitPercentage": 100
          },
          {
            "optionUuid": "aa684213-144e-4d95-133c-08dacc9b0e9b",
            "description": "Opção 3",
            "isCorrect": false,
            "totalOptionAnswers": 1,
            "hitQuantity": 0,
            "hitPercentage": 0
          }
        ]
      },
      {
        "questionUuid": "35164261-28a2-4a40-f20d-08dacc9b0e99",
        "description": "Questão 2",
        "totalAnswers": 6,
        "totalHitPercentage": 0,
        "options": [
          {
            "optionUuid": "9a1e3b31-2041-4b3c-133d-08dacc9b0e9b",
            "description": "Opção 1",
            "isCorrect": false,
            "totalOptionAnswers": 6,
            "hitQuantity": 0,
            "hitPercentage": 0
          },
          {
            "optionUuid": "0440643d-1938-4c57-133e-08dacc9b0e9b",
            "description": "Opção 2",
            "isCorrect": false,
            "totalOptionAnswers": 2,
            "hitQuantity": 0,
            "hitPercentage": 0
          },
          {
            "optionUuid": "e6accdf5-0f3c-4e20-133f-08dacc9b0e9b",
            "description": "Opção 3",
            "isCorrect": false,
            "totalOptionAnswers": 3,
            "hitQuantity": 0,
            "hitPercentage": 0
          },
          {
            "optionUuid": "66f8c9c6-cceb-42fb-1340-08dacc9b0e9b",
            "description": "Opção 4",
            "isCorrect": false,
            "totalOptionAnswers": 1,
            "hitQuantity": 0,
            "hitPercentage": 0
          }
        ]
      }
    ]
  }

  const response = await request(`api/analytics/generate-quiz-report/${params}`);
  return response.data;
}