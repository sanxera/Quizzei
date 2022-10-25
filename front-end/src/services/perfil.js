import request from '../utils/request';
import { getAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function getPerfil(uuid) {
  if (isEnvironmentDevelopment) {
    return {
      name: 'Senai Londrina',
      description: 'Serviço Nacional de Aprendizagem Industrial do Estado do Paraná, integrante do Sistema Fiep.',
      rating: 5,
    };
  };

  const auth = getAuthority();
  const response = await request(`api/quizzes-info/get-all-by-user`, {
    headers: {
      Authorization: `Bearer ${auth.token}`
    }
  })

  return response.data;
}

export async function listQuizzesByPerfil() {
  if (isEnvironmentDevelopment) {
    return [
      {
        quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
        title: "Quiz do Luiz",
        description: "Quiz sobre a vida do luiz",
        categoryDescription: "Categoria do Luiz",
        points: 5
      },
      {
        quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
        title: "Quiz do Luiz",
        description: "Quiz sobre a vida do luiz",
        categoryDescription: "Categoria do Luiz"
      },
      {
        quizInfoUuid: "a78ad28c-9d6b-4ef9-9776-ea2919ddf91d",
        title: "Quiz do Luiz",
        description: "Quiz sobre a vida do luiz",
        categoryDescription: "Categoria do Luiz"
      },
    ]
  };
}; 