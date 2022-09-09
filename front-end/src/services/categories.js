import request from '../utils/request';

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function list() {
  if (isEnvironmentDevelopment) {
    return {
      categories:
        [
          { idCategory: 1, name: "Geografia" },
          { idCategory: 2, name: "Arquitetura" },
          { idCategory: 3, name: "Teste" },
          { idCategory: 4, name: "Informática" },
          { idCategory: 5, name: "DASDAS" },
          { idCategory: 6, name: "Teste da Aula" },
          { idCategory: 7, name: "Categoria do Luiz" }
        ]
    };
  };

  const response = await request(`api/categories/get-all`);
  return response.data;
}