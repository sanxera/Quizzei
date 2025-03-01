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

export async function update(params) {
  const { quizInfoUuid, ...restParams } = params;
  if (isEnvironmentDevelopment) return { status: 'OK' };
  const auth = getAuthority();
  const response = await request(`api/quizzes-info/update-quiz-info/${quizInfoUuid}`, {
    method: 'PATCH',
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
    data: {
      ...restParams
    },
  });

  return response.data;
}

export async function createQuestions(quizInfoUuid, params) {
  if (isEnvironmentDevelopment) return { createdQuizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d" };
  const auth = getAuthority();
  const response = await request(`api/questions/create-questions-with-options/${quizInfoUuid}`, {
    method: 'PATCH',
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
          quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
          title: "Meu Quiz 1",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
          points: 5,
          imageName: 'Default',
          imageUrl: 'https://img.freepik.com/free-vector/curiosity-search-concept-illustration_114360-11031.jpg?w=1060&t=st=1680183682~exp=1680184282~hmac=c21946e90aad64c87feb2c6a0b994306df305c0af660e1771b5083bc4124a79f',
          permissionType: 1,
          quizAccess: null
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da2",
          title: "Meu Quiz 2",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
          imageName: 'Default',
          imageUrl: 'https://img.freepik.com/free-vector/curiosity-search-concept-illustration_114360-11031.jpg?w=1060&t=st=1680183682~exp=1680184282~hmac=c21946e90aad64c87feb2c6a0b994306df305c0af660e1771b5083bc4124a79f',
          permissionType: 2,
          quizAccess: {
            accessCode: '123456',
            initialDate: null,
            endDate: null
          }
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da3",
          title: "Meu Quiz 3",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
          imageName: 'Database',
          imageUrl: 'https://img.freepik.com/premium-vector/shared-db-machine-hybrid-network-stock-illustration-centralized-database-server-transmission-concept_135661-468.jpg?w=1060',
          permissionType: 3,
          quizAccess: {
            accessCode: '123456',
            initialDate: '2023-04-28T17:13:34.157Z',
            endDate: '2023-05-28T17:13:34.157Z'
          }
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

export async function listQuizzesFromUser(userUuid) {
  if (isEnvironmentDevelopment) {
    return {
      quizzesInfoDto: [
        {
          quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
          title: "Meu Quiz 1",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
          points: 5,
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da2",
          title: "Meu Quiz 2",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
        },
        {
          quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91da3",
          title: "Meu Quiz 3",
          description: "Quiz sobre a vida do luiz",
          categoryDescription: "Categoria do Luiz",
        },
      ]
    };
  };

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-quizzes-from-user-id/${userUuid}`, {
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
        }
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
              questionDescription: 'Questao 1',
              questionCategoryId: null,
              images: [{
                questionImageUuid: '0-312-31203123-',
                imageName: 'Paisagem',
                imageUrl: 'https://cursinhoparamedicina.com.br/wp-content/uploads/2022/10/Paisagem-1.jpg'
              }],
              options: [
                {
                  optionUuid: 'xxxxx',
                  optionDescription: 'descricao 1',
                  isCorrect: true,
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
              questionCategoryId: 2,
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
      questionCategoryId: question.questionCategoryId,
      images: question.images,
      options: question.options.map(option => {
        return {
          optionUuid: option.optionUuid,
          description: option.optionDescription,
          isCorrect: option.isCorrect,
        }
      })
    })
  })

  return { questions };
}

export async function startQuiz(params) {
  if (isEnvironmentDevelopment) return { quizProcessCreatedUuid: '239210-3912-93-1293-12' };
  if (!params) return;

  const { quizInfoUuid, password } = params;
  const auth = getAuthority();
  const response = await request(`api/quizzes-process/start-quiz/${quizInfoUuid}`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`,
    },
    data: {
      accessCode: password
    }
  });

  if (response.status !== 200) return {};

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

export async function listPublicQuizzesByCategory() {
  if (isEnvironmentDevelopment) {
    return {
      quizzesByCategories: [
        {
          categoryName: "Geografia",
          quizzesInfoResponses: [
            {
              quizInfoUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
              title: "Quiz do Romenin da ZN PARTE 2",
              description: "Quiz sobre a vida Romeno da ZN PARTE 2",
              categoryDescription: "Geografia",
              numberOfQuestions: 4,
              ownerNickName: "Manuel",
              imageName: 'Database',
              imageUrl: 'https://img.freepik.com/premium-vector/shared-db-machine-hybrid-network-stock-illustration-centralized-database-server-transmission-concept_135661-468.jpg?w=1060',
              permissionType: 1,
            },
            {
              quizInfoUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
              title: "Quiz do Romenin da ZN",
              description: "Quiz sobre a vida Romeno da ZN",
              categoryDescription: "Geografia",
              numberOfQuestions: 4,
              ownerNickName: "Manuel",
              permissionType: 2
            },
            {
              quizInfoUuid: "522d3b8e-f5b3-4c01-a6e7-0f39f10ce598",
              title: "Meu primeiro Quiz",
              description: "Um quiz feito para teste e ta ligado",
              categoryDescription: "Geografia",
              numberOfQuestions: 0,
              ownerNickName: "Manuel",
              permissionType: 3
            },
            {
              quizInfoUuid: "92b9d22f-9c62-478f-bfd1-601580e29909",
              title: "Quiz de Arquitetura",
              description: "Quiz sobre arquitetura de software e seus conceitos.",
              categoryDescription: "Geografia",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            }
          ]
        },
        {
          categoryName: "Arquitetura",
          quizzesInfoResponses: [
            {
              quizInfoUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
              title: "Quiz do Romenin da ZN PARTE 2",
              description: "Quiz sobre a vida Romeno da ZN PARTE 2",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "d636986e-6e2b-43a1-96b9-09b2bee2dfd7",
              title: "Quiz de Geografia",
              description: "Amigos 1",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
              title: "Quiz do Romenin da ZN",
              description: "Quiz sobre a vida Romeno da ZN",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "522d3b8e-f5b3-4c01-a6e7-0f39f10ce598",
              title: "Meu primeiro Quiz",
              description: "Um quiz feito para teste e ta ligado",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "64a678cc-e08b-4d8e-bab6-302f5cd44838",
              title: "Quiz do Sanxes I",
              description: "Quiz sobre a vida das batatas e peixes",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "866af655-0764-4a13-b6ff-742f6419e86d",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "e222933c-15c4-40f8-a4c4-a6d5872cde8f",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Arquitetura",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
          ]
        },
        {
          categoryName: "Teste",
          quizzesInfoResponses: [
            {
              quizInfoUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
              title: "Quiz do Romenin da ZN PARTE 2",
              description: "Quiz sobre a vida Romeno da ZN PARTE 2",
              categoryDescription: "Teste",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "d636986e-6e2b-43a1-96b9-09b2bee2dfd7",
              title: "Quiz de Geografia",
              description: "Amigos 1",
              categoryDescription: "Teste",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
              title: "Quiz do Romenin da ZN",
              description: "Quiz sobre a vida Romeno da ZN",
              categoryDescription: "Teste",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "522d3b8e-f5b3-4c01-a6e7-0f39f10ce598",
              title: "Meu primeiro Quiz",
              description: "Um quiz feito para teste e ta ligado",
              categoryDescription: "Teste",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "64a678cc-e08b-4d8e-bab6-302f5cd44838",
              title: "Quiz do Sanxes I",
              description: "Quiz sobre a vida das batatas e peixes",
              categoryDescription: "Teste",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "92b9d22f-9c62-478f-bfd1-601580e29909",
              title: "Quiz de Arquitetura",
              description: "Quiz sobre arquitetura de software e seus conceitos.",
              categoryDescription: "Teste",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "866af655-0764-4a13-b6ff-742f6419e86d",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Teste",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "e222933c-15c4-40f8-a4c4-a6d5872cde8f",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Teste",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Teste",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Teste",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            }
          ]
        },
        {
          categoryName: "Informática",
          quizzesInfoResponses: [
            {
              quizInfoUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
              title: "Quiz do Romenin da ZN PARTE 2",
              description: "Quiz sobre a vida Romeno da ZN PARTE 2",
              categoryDescription: "Informática",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "d636986e-6e2b-43a1-96b9-09b2bee2dfd7",
              title: "Quiz de Geografia",
              description: "Amigos 1",
              categoryDescription: "Informática",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
              title: "Quiz do Romenin da ZN",
              description: "Quiz sobre a vida Romeno da ZN",
              categoryDescription: "Informática",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "522d3b8e-f5b3-4c01-a6e7-0f39f10ce598",
              title: "Meu primeiro Quiz",
              description: "Um quiz feito para teste e ta ligado",
              categoryDescription: "Informática",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "64a678cc-e08b-4d8e-bab6-302f5cd44838",
              title: "Quiz do Sanxes I",
              description: "Quiz sobre a vida das batatas e peixes",
              categoryDescription: "Informática",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "92b9d22f-9c62-478f-bfd1-601580e29909",
              title: "Quiz de Arquitetura",
              description: "Quiz sobre arquitetura de software e seus conceitos.",
              categoryDescription: "Informática",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "866af655-0764-4a13-b6ff-742f6419e86d",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Informática",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "e222933c-15c4-40f8-a4c4-a6d5872cde8f",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Informática",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "Informática",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "Informática",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            }
          ]
        },
        {
          categoryName: "DASDAS",
          quizzesInfoResponses: [
            {
              quizInfoUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
              title: "Quiz do Romenin da ZN PARTE 2",
              description: "Quiz sobre a vida Romeno da ZN PARTE 2",
              categoryDescription: "DASDAS",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "d636986e-6e2b-43a1-96b9-09b2bee2dfd7",
              title: "Quiz de Geografia",
              description: "Amigos 1",
              categoryDescription: "DASDAS",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
              title: "Quiz do Romenin da ZN",
              description: "Quiz sobre a vida Romeno da ZN",
              categoryDescription: "DASDAS",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "522d3b8e-f5b3-4c01-a6e7-0f39f10ce598",
              title: "Meu primeiro Quiz",
              description: "Um quiz feito para teste e ta ligado",
              categoryDescription: "DASDAS",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "64a678cc-e08b-4d8e-bab6-302f5cd44838",
              title: "Quiz do Sanxes I",
              description: "Quiz sobre a vida das batatas e peixes",
              categoryDescription: "DASDAS",
              numberOfQuestions: 4,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "92b9d22f-9c62-478f-bfd1-601580e29909",
              title: "Quiz de Arquitetura",
              description: "Quiz sobre arquitetura de software e seus conceitos.",
              categoryDescription: "DASDAS",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "866af655-0764-4a13-b6ff-742f6419e86d",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "DASDAS",
              numberOfQuestions: 1,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "e222933c-15c4-40f8-a4c4-a6d5872cde8f",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "DASDAS",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "de9fce3b-f19b-47ab-8a70-bc2abc5c6e69",
              title: "Quiz do Usuário 1",
              description: "Quiz de teste para apresentação",
              categoryDescription: "DASDAS",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            },
            {
              quizInfoUuid: "000432b9-9a8d-4df1-a3b5-e290ab47b665",
              title: "Quiz de Estudos Gerais",
              description: "Estuda",
              categoryDescription: "DASDAS",
              numberOfQuestions: 0,
              ownerNickName: "Manuel"
            }
          ]
        }
      ]
    };
  };

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-quizzes-by-category-from-different-users`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
};



export async function ratingQuiz(quizProcessUuid, value) {
  const auth = getAuthority();
  const response = await request(`api/quizzes-process/rating-quiz/${quizProcessUuid}?rate=${value}`, {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
};


export async function historyQuiz() {
  if (isEnvironmentDevelopment) {
    return {
      "userUuid": "bb819f30-64c4-405e-97cf-1dabc6ec5f6b",
      "quizzesHistoryInformation": [
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 10,
          "correctAnswers": 2,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        },
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 10,
          "correctAnswers": 5,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        },
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 4,
          "correctAnswers": 0,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        },
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 4,
          "correctAnswers": 0,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        },
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 4,
          "correctAnswers": 0,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        },
        {
          "quizInfoUuid": "f16a5983-acd4-4507-947e-1237f8db0349",
          "title": "Quiz do Jonas em",
          "description": "Quiz do jonas para testar umas coisas",
          "categoryDescription": "Categoria do Romeno",
          "numberOfQuestions": 4,
          "correctAnswers": 0,
          "rate": 0,
          "ownerNickName": "JoninhaJoia"
        }
      ]
    };
  }

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-quizzes-history-from-user`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
}

export async function getDefaultLogo() {
  if (isEnvironmentDevelopment) return [
    {
      imageName: "Default",
      imageUrl: "https://img.freepik.com/free-vector/curiosity-search-concept-illustration_114360-11031.jpg?w=1060&t=st=1680183682~exp=1680184282~hmac=c21946e90aad64c87feb2c6a0b994306df305c0af660e1771b5083bc4124a79f"
    },
    {
      imageName: "Database",
      imageUrl: "https://img.freepik.com/premium-vector/shared-db-machine-hybrid-network-stock-illustration-centralized-database-server-transmission-concept_135661-468.jpg?w=1060"
    },
    {
      imageName: "Idiomas",
      imageUrl: "https://img.freepik.com/free-vector/hand-drawn-english-school-illustration_23-2149491453.jpg?w=1060&t=st=1679355352~exp=1679355952~hmac=2ebbf87f9e9e6295bd8d793bc8b2d607fb21edec1da9a1ebec077ac0815dcd4b"
    },
    {
      imageName: "Matematica",
      imageUrl: "https://img.freepik.com/free-vector/mathematics-concept-illustration_114360-3972.jpg?t=st=1679355371~exp=1679355971~hmac=3ccb6cb5432c2338999501f7e761daa64f9aacf4b8f42ac6f46419a3a4c6ec67"
    }
  ];

  const auth = getAuthority();
  const response = await request(`api/files/get-default-images`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
  });

  return response.data.defaultImages;
}

export async function removeQuestionFile(imageUuid) {
  if (isEnvironmentDevelopment) return {
    deleted: true,
  };

  const auth = getAuthority();
  const response = await request(`api/files/delete-image/${imageUuid}`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
  });

  return response.data;
}

export async function getQuestionCategories() {
  if (isEnvironmentDevelopment) return {
    questionsCategories: [
      {
        idCategory: 1,
        name: 'DevOps',
      },
      {
        idCategory: 2,
        name: 'TI',
      },
      {
        idCategory: 3,
        name: 'Redes',
      },
    ]
  };

  const auth = getAuthority();
  const response = await request(`api/question-category/get-all`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
  });

  return response.data;
}

export async function createQuestionCategory(name) {
  if (isEnvironmentDevelopment) return {
    createdId: 2
  };

  const auth = getAuthority();
  const response = await request(`api/question-category/create`, {
    method: 'POST',
    data: {
      name
    },
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
  });

  return response.data;
}
