import request from '../utils/request';
import { getAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';


export async function filterAll(search) {
  if (isEnvironmentDevelopment) {
    return {
      quizzes: [
        {
          quizUuid: "f81d1f5e-bcd1-4610-a206-02bec0e19daa",
          title: "Quiz do Romenin da ZN PARTE 2"
        },
        {
          quizUuid: "d636986e-6e2b-43a1-96b9-09b2bee2dfd7",
          title: "Quiz de Geografia"
        },
        {
          quizUuid: "db8d7872-eeb2-4d6a-ab33-0aeae478307a",
          title: "Quiz do Romenin da ZN"
        },
        {
          quizUuid: "64a678cc-e08b-4d8e-bab6-302f5cd44838",
          title: "Quiz do Sanxes I"
        },
        {
          quizUuid: "92b9d22f-9c62-478f-bfd1-601580e29909",
          title: "Quiz de Arquitetura"
        },
        {
          quizUuid: "e222933c-15c4-40f8-a4c4-a6d5872cde8f",
          title: "Quiz de Estudos Gerais"
        },
        {
          quizUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d1",
          title: "Meu Quiz 1"
        }
      ],
      users: [
        {
          userUuid: "220fe8e1-b06d-4da1-bf33-2e6f5e4dbcb8",
          name: "Manuel"
        },
        {
          userUuid: "3e11081f-09a4-4d6f-9b0d-4fb8fceeb6b6",
          name: "Paulo Sanches"
        },
        {
          userUuid: "75c849d1-a28e-428a-bf48-d8ffa576d5ec",
          name: "Romeno da Silva"
        },
        {
          userUuid: "9f626ca5-6891-42f0-ba75-e7b1592714ac",
          name: "Avila"
        },
        {
          userUuid: "f3cb6542-e6a7-4ce5-b88c-b63b62aa9b33",
          name: "Jaozin"
        }
      ]
    }
  };

  const auth = getAuthority();
  const response = await request(`api/search/${search}`, {
    method: 'PATCH',
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
}