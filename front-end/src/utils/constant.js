import moment from 'moment';

export const PERMISSION_TYPE = {
  1: 'PUBLIC',
  2: 'PRIVATE',
  3: 'TEMPORARY'
};

export const PERMISSION_TYPE_TAGS = {
  1: { color: 'green', title: 'Publico' },
  2: { color: 'red', title: 'Privado' },
  3: { color: 'orange', title: 'Temporario' },
}

export const DEFAULT_DATE = [moment(new Date(), 'DD/MM/YYYY'), moment(new Date(), 'DD/MM/YYYY').add(1, 'month')];

export const GENERATE_PERIOD_DATE = ({ initialDate, endDate }) => {
  if (!initialDate || !endDate) return DEFAULT_DATE;
  return [moment(new Date(initialDate), 'DD/MM/YYYY'), moment(new Date(endDate), 'DD/MM/YYYY')];
}


export const DEFAULT_THEME = 'https://img.freepik.com/free-vector/curiosity-search-concept-illustration_114360-11031.jpg?w=1060&t=st=1680183682~exp=1680184282~hmac=c21946e90aad64c87feb2c6a0b994306df305c0af660e1771b5083bc4124a79f';