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