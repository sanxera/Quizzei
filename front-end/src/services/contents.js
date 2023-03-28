import request from '../utils/request';
// import { getAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function getFilesFromQuiz(quizInfoUuid) {
  if (isEnvironmentDevelopment) {
    return {
      filesResponse: [
        {
          fileCreatedUuid: "318ccb93-5db5-40e8-c089-08dac766e26e",
          fileName: "Atividade 1 - Guilherme Sanches.pdf"
        },
        {
          fileCreatedUuid: "f7303e23-f97c-47e9-d991-08dac7686a86",
          fileName: "Atividade 2 - Guilherme Sanches.pdf"
        }
      ]
    };
  };

  const response = await request(`api/files/get-files-from-quiz-information/${quizInfoUuid}`);
  return response.data;
}

export async function downloadFile(fileUuid) {
  const response = await request(`api/files/download-file/${fileUuid}`);
  return response.data;
};

export async function getAllFiles() {
  if (isEnvironmentDevelopment) {
    return {
      filesResponse: [
        {
          fileCreatedUuid: "318ccb93-5db5-40e8-c089-08dac766e26e",
          fileName: "Atividade 1 - Guilherme Sanches.pdf"
        },
        {
          fileCreatedUuid: "f7303e23-f97c-47e9-d991-08dac7686a86",
          fileName: "Atividade 2 - Guilherme Sanches.pdf"
        }
      ]
    };
  };

  const response = await request(`api/files/get-all-files`);
  return response.data;
}