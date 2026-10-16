// Configuración base de conexión con la API BikeSyS
const API_BASE = 'https://localhost:7235/api';
// const API_BASE = 'http://localhost:5044/api'; // Descomentar si se ejecuta con perfil HTTP

function getToken() {
    return localStorage.getItem('bikeSysToken') || '';
}

function getEmailUsuario() {
    return localStorage.getItem('bikeSysEmail') || '';
}

function esAdmin() {
    const email = getEmailUsuario().toLowerCase();
    return email.includes('admin');
}

function guardarSesion(token, email) {
    localStorage.setItem('bikeSysToken', token);
    localStorage.setItem('bikeSysEmail', email || '');
}

function cerrarSesionApi() {
    localStorage.removeItem('bikeSysToken');
    localStorage.removeItem('bikeSysEmail');
    window.location.href = 'index.html';
}

async function apiFetch(endpoint, options = {}) {
    const headers = {
        'Content-Type': 'application/json',
        ...(options.headers || {})
    };

    const token = getToken();
    if (token) {
        headers.Authorization = `Bearer ${token}`;
    }

    let response;
    try {
        response = await fetch(`${API_BASE}${endpoint}`, {
            ...options,
            headers
        });
    } catch (error) {
        throw new Error(
            'No se pudo conectar con la API. Verificá que el backend esté en ejecución en Visual Studio y que el puerto coincida con API_BASE.'
        );
    }

    if (response.status === 401) {
        const errorText = await response.text();
        localStorage.removeItem('bikeSysToken');
        if (!window.location.pathname.endsWith('index.html')) {
            window.location.href = 'index.html';
        }
        throw new Error(errorText || 'Sesión expirada o credenciales inválidas.');
    }

    if (!response.ok) {
        const contentType = response.headers.get('content-type') || '';
        if (contentType.includes('application/json')) {
            const errJson = await response.json();
            const mensaje = errJson.message || errJson.Mensaje || errJson.title || JSON.stringify(errJson);
            throw new Error(mensaje);
        }
        const body = await response.text();
        throw new Error(body || `Error HTTP ${response.status}`);
    }

    if (response.status === 204) {
        return null;
    }

    const contentType = response.headers.get('content-type') || '';
    return contentType.includes('application/json') ? response.json() : null;
}

async function apiLogin(email, clave) {
    const result = await apiFetch('/Usuarios/login', {
        method: 'POST',
        body: JSON.stringify({ email, clave })
    });

    const token = result?.token || result?.Token || '';
    if (!token) {
        throw new Error('La API no devolvió un token de sesión válido.');
    }

    guardarSesion(token, email);
    return result;
}

function requireApiLogin() {
    if (!getToken()) {
        window.location.href = 'index.html';
    }
}

function requireAdmin() {
    requireApiLogin();
    if (!esAdmin()) {
        window.location.href = 'menu.html';
    }
}