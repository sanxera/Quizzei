import request from '../utils/request';
import { getAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function create(params) {
  if (isEnvironmentDevelopment) return { createdQuizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d" };
  const auth = getAuthority();
  const response = await request(`api/quizzes-info/create-quiz-info`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
    data: {
      ...params
    },
  });

  return response.data;
}

export async function createQuestions(quizInfoUuid, params) {
  if (isEnvironmentDevelopment) return { createdQuizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d" };
  const auth = getAuthority();
  const response = await request(`api/questions/create-questions-with-options/${quizInfoUuid}`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`,
    },
    data: {
      ...params
    },
  });

  return response.data;
}

export async function listMyQuizzes() {
  if (isEnvironmentDevelopment) {
    return {
      quizzesInfoDto: [
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da1",
          title: "Meu Quiz 1",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
          points: 5
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da2",
          title: "Meu Quiz 2",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da3",
          title: "Meu Quiz 3",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
      ]
    };
  };

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-all-by-user`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
};

export async function listPublicQuizzes() {
  if (isEnvironmentDevelopment) {
    return {
      quizzesInfoDto: [
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d1",
          title: "Public Quiz 1",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf912",
          title: "Public Quiz 2",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf913",
          title: "Public Quiz 3",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf914",
          title: "Public Quiz 4",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf915",
          title: "Public Quiz 5",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d6",
          title: "Public Quiz 6",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d7",
          title: "Public Quiz 7",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d8",
          title: "Public Quiz 8",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz"
        },
      ]
    };
  };

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-all-by-different-users`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
};

export async function listQuestions(quizInfoUuid) {
  let response;

  switch (isEnvironmentDevelopment) {
    case true:
      response = {
        data: {
          questions: [
            {
              questionUuid: 'xxxx',
              questionDescription: 'Questão 1',
              options: [
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 1',
                },
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 2',
                },
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 3',
                },
              ]
            },
            {
              questionUuid: 'xxxx',
              questionDescription: 'Questão 2',
              options: [
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 1',
                },
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 2',
                },
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'Descricao 3',
                },
              ]
            }
          ]
        }
      };
      break;

    default:
      if (!quizInfoUuid) return;
      const auth = getAuthority();
      response = await request(`api/questions/get-questions-by-quiz/${quizInfoUuid}`, {
        headers: {
          Authorization: `Bearer ${auth.token}`,
        }
      })
  }

  const questions = [];

  await response.data.questions.forEach(async question => {
    await questions.push({
      questionUuid: question.questionUuid,
      description: question.questionDescription,
      options: question.options.map(option => {
        return {
          optionUuid: option.optionUuid,
          description: option.optionDescription
        }
      })
    })
  })

  return { questions };
}

export async function startQuiz(quizInfoUuid) {
  if (isEnvironmentDevelopment) return { quizProcessCreatedUuid: '239210-3912-93-1293-12' };
  if (!quizInfoUuid) return;
  const auth = getAuthority();
  const response = await request(`api/quizzes-process/start-quiz/${quizInfoUuid}`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`,
    },
  });

  return response.data;
}

export async function answerQuestions(params = {}) {
  if (isEnvironmentDevelopment) return { totalQuestions: 10, correctAnswers: 5 };
  const { quizProcessUuid, ...rest } = params;
  if (!quizProcessUuid) return;

  const auth = getAuthority();
  const response = await request(`api/answer/answer-questions-by-process/${quizProcessUuid}`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`,
    },
    data: {
      ...rest
    }
  });

  return response.data;
}