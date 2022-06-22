export const toBase64 = (file) =>
  new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result.replace("data:", "").replace(/^.+,/, ""));
    reader.onerror = (error) => reject(error);
  });

export function getCookie(name) {
  const value = `; ${document.cookie}`;
  const parts = value.split(`; ${name}=`);
  if (parts.length === 2) return parts.pop().split(";").shift();
}

export function setCookie(name, value, days) {
  var expires = "";
  if (days) {
    var date = new Date();
    date.setTime(date.getTime() + days * 24 * 60 * 60 * 1000);
    expires = "; expires=" + date.toUTCString();
  }
  document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

export function eraseCookie(name) {
  let d = new Date();
  d.setTime(d.getTime() - 1);
  let expires = "expires=" + d.toUTCString();
  document.cookie = `${name}=` + ";" + expires + ";path=/";
}

export function formatDate(date) {
  if (!date) return "";
  if (date === "0001-01-01T00:00:00") return "";
  let result = new Date(date);
  result = new Date(Date.UTC(result.getFullYear(), result.getMonth(), result.getDate(), result.getHours(), result.getMinutes()));
  return result.toISOString().slice(0, 10);
}

export function formatTime(time, upToSecs = false) {
  if (!time) return "";
  if (time === "0001-01-01T00:00:00") return "";
  let hours = new Date(time).getHours();
  let minutes = new Date(time).getMinutes();
  let secs = new Date(time).getSeconds();

  if (hours === 0) hours = "00";
  else if (hours < 10) hours = "0" + hours;

  if (minutes === 0) minutes = "00";
  else if (minutes < 10) minutes = "0" + minutes;

  if (secs === 0) secs = "00";
  else if (secs < 10) secs = "0" + secs;

  if (!upToSecs) return `${hours}:${minutes}`;
  else return `${hours}:${minutes}:${secs}`;
}
