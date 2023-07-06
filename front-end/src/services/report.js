import request from '../utils/request';

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function getReport(params) {
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
            "totalOptionAnswers": 8,
            "hitQuantity": 8,
            "totalOptionAnswersPercentage": 90
          },
          {
            "optionUuid": "8b1204ea-6677-447f-133b-08dacc9b0e9b",
            "description": "Opção 2",
            "isCorrect": true,
            "totalOptionAnswers": 1,
            "hitQuantity": 1,
            "totalOptionAnswersPercentage": 10
          },
          {
            "optionUuid": "aa684213-144e-4d95-133c-08dacc9b0e9b",
            "description": "Opção 3",
            "isCorrect": false,
            "totalOptionAnswers": 1,
            "hitQuantity": 0,
            "totalOptionAnswersPercentage": 20
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
            "totalOptionAnswers": 0,
            "hitQuantity": 0,
            "totalOptionAnswersPercentage": 0
          },
          {
            "optionUuid": "0440643d-1938-4c57-133e-08dacc9b0e9b",
            "description": "Opção 2",
            "isCorrect": false,
            "totalOptionAnswers": 2,
            "hitQuantity": 0,
            "totalOptionAnswersPercentage": 0
          },
          {
            "optionUuid": "e6accdf5-0f3c-4e20-133f-08dacc9b0e9b",
            "description": "Opção 3",
            "isCorrect": false,
            "totalOptionAnswers": 3,
            "hitQuantity": 0,
            "totalOptionAnswersPercentage": 0
          },
          {
            "optionUuid": "66f8c9c6-cceb-42fb-1340-08dacc9b0e9b",
            "description": "Opção 4",
            "isCorrect": false,
            "totalOptionAnswers": 1,
            "hitQuantity": 0,
            "totalOptionAnswersPercentage": 0
          }
        ]
      }
    ]
  }

  const response = await request(`api/analytics/generate-quiz-report/${params}`);
  return response.data;
}

export async function getUsersByQuiz(quizUuid) {
  if (isEnvironmentDevelopment) {
    return {
      "users": [
        {
          "userUuid": "9ccb7904-9c2e-455a-8eff-4bf3a1370152",
          "name": "luizete",
          "quizzesProcess": [
            {
              "quizProcessUuid": "2544c891-b2b7-4570-8df5-08dacc9f23e2",
              "startedDate": "2022-11-22T12:35:10.027",
              "status": 2
            },
            {
              "quizProcessUuid": "2fcb9b38-22bc-4735-68a9-08dacceb1b57",
              "startedDate": "2022-11-22T22:18:31.38",
              "status": 1
            }
          ]
        },
        {
          "userUuid": "eb9f7a99-6a8f-4e19-b562-aea8f3ae46a8",
          "name": "LucasSenai",
          "quizzesProcess": [
            {
              "quizProcessUuid": "a6bcfc0c-03c9-458b-8df7-08dacc9f23e2",
              "startedDate": "2022-11-22T12:59:26.867",
              "status": 2
            }
          ]
        },
        {
          "userUuid": "0323247c-110c-4411-a693-232ad846aa94",
          "name": "AvilaSenai",
          "quizzesProcess": [
            {
              "quizProcessUuid": "60adedbb-8d4d-44f8-19b2-08db29c5e629",
              "startedDate": "2023-03-21T01:36:54.967",
              "status": 1
            },
            {
              "quizProcessUuid": "5b2f2e96-23fd-4020-19b3-08db29c5e629",
              "startedDate": "2023-03-21T01:37:00.363",
              "status": 1
            },
            {
              "quizProcessUuid": "3258d694-dd02-486a-0c85-08db2a29ab8b",
              "startedDate": "2023-03-21T13:31:06.297",
              "status": 2
            },
            {
              "quizProcessUuid": "ec44d233-2d44-49c8-9859-08db356a579b",
              "startedDate": "2023-04-04T21:11:58.727",
              "status": 2
            },
            {
              "quizProcessUuid": "47844c7c-c158-45bd-b406-08db3ebc46b8",
              "startedDate": "2023-04-16T17:50:56.433",
              "status": 2
            },
            {
              "quizProcessUuid": "67d8da2f-00e4-42cd-cd57-08db2a4e06fc",
              "startedDate": "2023-03-21T17:51:21.597",
              "status": 2
            }
          ]
        },
        {
          "userUuid": "06d4a085-b89a-44e7-944c-7f019d2a10ad",
          "name": "cleber123",
          "quizzesProcess": [
            {
              "quizProcessUuid": "26424394-2e38-45f7-83be-08db2a4c65a3",
              "startedDate": "2023-03-21T17:39:41.413",
              "status": 2
            }
          ]
        }
      ]
    }
  }

  const response = await request(`api/quizzes-process/get-users-by-quiz/${quizUuid}`);
  return response.data;
}

export async function getReportPerQuizProcess(quizProcessUuid) {
  if (isEnvironmentDevelopment) {
    return {
      "quizUuid": "0f9eec9c-ec41-4f42-94e3-01a700506d6b",
      "quizDescription": " Mauris blandit laoreet leo, eget tempus nisi dictum id. Nulla facilisi. Nam vitae iaculis est. Nam quis eleifend diam",
      "totalQuestions": 2,
      "questions": [
        {
          "questionUuid": "1a0f3bba-b978-4b3d-f20c-08dacc9b0e99",
          "description": "Questão 1",
          "userAnswerIsCorrect": true,
          "options": [
            {
              "optionUuid": "3b9c9d44-d4c1-45f3-133a-08dacc9b0e9b",
              "description": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur tristique pellentesque ante in pulvinar. In tortor nunc, mollis vitae malesuada vel, malesuada sit amet tellus. Nullam sit amet felis at lorem consequat faucibus. Suspendisse finibus erat a luctus vestibulum. Nulla facilisi. In hendrerit ipsum ut libero suscipit, et sollicitudin dui lacinia",
              "isCorrect": true,
              "userCheck": true
            },
            {
              "optionUuid": "8b1204ea-6677-447f-133b-08dacc9b0e9b",
              "description": "Opção 2",
              "isCorrect": true,
              "userCheck": false
            },
            {
              "optionUuid": "aa684213-144e-4d95-133c-08dacc9b0e9b",
              "description": "Opção 3",
              "isCorrect": false,
              "userCheck": false
            }
          ]
        },
        {
          "questionUuid": "35164261-28a2-4a40-f20d-08dacc9b0e99",
          "description": "Questão 2",
          "userAnswerIsCorrect": false,
          "options": [
            {
              "optionUuid": "9a1e3b31-2041-4b3c-133d-08dacc9b0e9b",
              "description": "Opção 1",
              "isCorrect": true,
              "userCheck": false
            },
            {
              "optionUuid": "0440643d-1938-4c57-133e-08dacc9b0e9b",
              "description": "Opção 2",
              "isCorrect": false,
              "userCheck": true
            },
            {
              "optionUuid": "e6accdf5-0f3c-4e20-133f-08dacc9b0e9b",
              "description": "Opção 3",
              "isCorrect": false,
              "userCheck": false
            },
            {
              "optionUuid": "66f8c9c6-cceb-42fb-1340-08dacc9b0e9b",
              "description": "Opção 4",
              "isCorrect": true,
              "userCheck": false
            }
          ]
        }
      ]
    }
  }

  const response = await request(`api/analytics/generate-report-per-process/${quizProcessUuid}`);
  return response.data;
}


export async function getByQuestionsCategory(quizProcessUuid) {
  if (isEnvironmentDevelopment) {
    return {
      "quizUuid": "0f9eec9c-ec41-4f42-94e3-01a700506d6b",
      "quizDescription": " Mauris blandit laoreet leo, eget tempus nisi dictum id. Nulla facilisi. Nam vitae iaculis est. Nam quis eleifend diam",
      "totalCompletedQuiz": 9,
      "totalNotCompletedQuiz": 3,
      "totalQuestions": 3,
      "questionsCategories": [
        {
          "questionCategoryId": 3,
          "questionCategoryDescription": "Conhecimentos Gerais",
          "totalQuestions": 1,
          "totalHitPercentage": 90,
          "questions": [
            {
              "questionUuid": "1a0f3bba-b978-4b3d-f20c-08dacc9b0e99",
              "description": "Questão 1",
              "totalAnswers": 11,
              "totalHitPercentage": 90,
              "options": [
                {
                  "optionUuid": "3b9c9d44-d4c1-45f3-133a-08dacc9b0e9b",
                  "description": "Opção 1",
                  "isCorrect": true,
                  "totalOptionAnswers": 9,
                  "totalOptionAnswersPercentage": 81,
                  "hitQuantity": 9,
                  "hitPercentage": 100
                },
                {
                  "optionUuid": "8b1204ea-6677-447f-133b-08dacc9b0e9b",
                  "description": "Opção 2",
                  "isCorrect": true,
                  "totalOptionAnswers": 1,
                  "totalOptionAnswersPercentage": 9,
                  "hitQuantity": 1,
                  "hitPercentage": 100
                },
                {
                  "optionUuid": "aa684213-144e-4d95-133c-08dacc9b0e9b",
                  "description": "Opção 3",
                  "isCorrect": false,
                  "totalOptionAnswers": 1,
                  "totalOptionAnswersPercentage": 9,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                }
              ]
            }
          ]
        },
        {
          "questionCategoryId": 1,
          "questionCategoryDescription": "Informática",
          "totalQuestions": 2,
          "totalHitPercentage": 0,
          "questions": [
            {
              "questionUuid": "35164261-28a2-4a40-f20d-08dacc9b0e99",
              "description": "Questão 2",
              "totalAnswers": 9,
              "totalHitPercentage": 0,
              "options": [
                {
                  "optionUuid": "9a1e3b31-2041-4b3c-133d-08dacc9b0e9b",
                  "description": "Opção 1",
                  "isCorrect": false,
                  "totalOptionAnswers": 7,
                  "totalOptionAnswersPercentage": 77,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                },
                {
                  "optionUuid": "0440643d-1938-4c57-133e-08dacc9b0e9b",
                  "description": "Opção 2",
                  "isCorrect": false,
                  "totalOptionAnswers": 1,
                  "totalOptionAnswersPercentage": 11,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                },
                {
                  "optionUuid": "e6accdf5-0f3c-4e20-133f-08dacc9b0e9b",
                  "description": "Opção 3",
                  "isCorrect": false,
                  "totalOptionAnswers": 0,
                  "totalOptionAnswersPercentage": 0,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                },
                {
                  "optionUuid": "66f8c9c6-cceb-42fb-1340-08dacc9b0e9b",
                  "description": "Opção 4",
                  "isCorrect": false,
                  "totalOptionAnswers": 1,
                  "totalOptionAnswersPercentage": 11,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                }
              ]
            },
            {
              "questionUuid": "7b65b877-9875-4e31-d18e-08db573959a1",
              "description": "string",
              "totalAnswers": 0,
              "totalHitPercentage": 0,
              "options": [
                {
                  "optionUuid": "040df819-ffee-4110-87e5-08db573959a6",
                  "description": "string",
                  "isCorrect": true,
                  "totalOptionAnswers": 0,
                  "totalOptionAnswersPercentage": 0,
                  "hitQuantity": 0,
                  "hitPercentage": 0
                }
              ]
            }
          ]
        }
      ]
    }
  }

  const response = await request(`api/analytics/generate-quiz-report-per-category/${quizProcessUuid}`);
  return response.data;
}