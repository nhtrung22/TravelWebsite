export const EmailRegExp = "^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$";

export const PhoneNumberRegExp = "^[+]?[\\d]+[ -\\d]*[\\d]$";

export const ValidTextRegExp = "^[^;%<>\\$'\"]*$";

export const lngs = {
  en: { nativeName: "English", code: "en" },
  sv: { nativeName: "Svenska", code: "sv" },
};

export const roles = {
  user: "user",
  admin: "admin",
};

export const users = [
  {
    username: "admin",
    password: "admin",
    role: roles.admin,
  },
  {
    username: "user",
    password: "user",
    role: roles.user,
  },
];

export const QueryParameterNames = {
  ReturnUrl: "returnUrl",
  Message: "message",
};

export const UserType = {
  Client: 0,
  Owner: 1,
  Admin: 2,
};

export const PaymentStatus = {
  Pending: 0,
  Reserved: 1,
  Paid: 2,
  Waiting: 3,
  Cancelled: 4,
};

export const PaymentMethod = {
  Card: 1,
  PayUponCheckIn: 2,
};
