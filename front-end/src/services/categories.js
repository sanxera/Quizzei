import axios from "axios";

export async function list(params) {
  const request = axios.create({
    baseURL: 'https://localhost:44331',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Credentials': true,
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'x-requested-with',
    }
  });
  const response = await request(`api/categories/get-all`);

  return response.data;
  // return {
  //   categories:
  //     [
  //       { idCategory: 1, name: "Geografia" },
  //       { idCategory: 2, name: "Arquitetura" },
  //       { idCategory: 3, name: "Teste" },
  //       { idCategory: 4, name: "Informática" },
  //       { idCategory: 5, name: "DASDAS" },
  //       { idCategory: 6, name: "Teste da Aula" },
  //       { idCategory: 7, name: "Categoria do Luiz" }
  //     ]
  // }
}