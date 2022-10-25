import request from '../utils/request';
import { getAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function getPerfil(uuid) {
  if (isEnvironmentDevelopment) {
    return {
      userUuid: "220fe8e1-b06d-4da1-bf33-2e6f5e4dbcb8",
      email: "manuel123@gmail.com",
      nickName: "Manuel",
      roleUuid: "0bd3463c-95dd-4dce-ae51-7c2c62609860",
      roleName: "Aluno"
    };
  };

  const auth = getAuthority();
  const response = await request(`api/users/get-user-details?userUuid=${uuid}`, {
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