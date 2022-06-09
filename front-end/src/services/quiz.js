import { getAuthority } from "../utils/auth";
import request from "../utils/request";

const { REACT_APP_QUIZZEI_API_URL } = process.env

export async function create(params) {
  const auth = getAuthority();
  const response = await request(`${REACT_APP_QUIZZEI_API_URL}/api/quizzes-info/create-quiz-info`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
    data: {
      ...params
    },
  });

  return response.data;
  // return { createdQuizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d" }
}

export async function createQuestions(quizInfoUuid, params) {
  const auth = getAuthority();
  const response = await request(`${REACT_APP_QUIZZEI_API_URL}/api/questions/create-questions-with-options`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`,
      quizInfoUuid
    },
    data: {
      ...params
    },
  });

  return response.data;
  // return { createdQuizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d" }
}

export async function listMyQuizzes() {
  const auth = getAuthority();
  const response = await request(`${REACT_APP_QUIZZEI_API_URL}/api/quizzes-info/get-all-by-user`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
  // return {
  //   quizzesInfoDto: [
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //   ]
  // }
};

export async function listPublicQuizzes() {
  const auth = getAuthority();
  const response = await request(`${REACT_APP_QUIZZEI_API_URL}/api/quizzes-info/get-all-by-different-users`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
  // return {
  //   quizzesInfoDto: [
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //     {
  //       quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
  //       title: "Quiz do Luiz",
  //       description: "Quiz sobre a vida do luiz",
  //       categoryDescription: "Categoria do Luiz"
  //     },
  //   ]
  // }
};