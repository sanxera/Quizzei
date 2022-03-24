import axios from 'axios'
const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env

const request = axios.create({
    baseURL: REACT_APP_QUIZZEI_BACKEND_URL,
    headers: {
        'Content-type': 'application/json',
        'Access-Control-Allow-Credentials': true,
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Headers': 'x-requested-with',
    }
});

export default request;