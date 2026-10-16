// Funciones utilitarias de formato y diseño general

function money(valor) {
    return new Intl.NumberFormat('es-AR', {
        style: 'currency',
        currency: 'ARS',
        maximumFractionDigits: 0
    }).format(Number(valor) || 0);
}

function today() {
    return new Date().toISOString().slice(0, 10);
}

function esc(texto) {
    return String(texto ?? '').replace(/[&<>"']/g, char => ({
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#039;'
    }[char]));
}

function fmtDate(fechaIso) {
    if (!fechaIso) return '-';
    const limpia = String(fechaIso).slice(0, 10);
    const partes = limpia.split('-');
    return partes.length === 3 ? `${partes[2]}/${partes[1]}/${partes[0]}` : fechaIso;
}

function currentUser() {
    const email = localStorage.getItem('bikeSysEmail') || 'Usuario';
    const rol = esAdmin() ? 'Administrador' : 'Operador';
    return { nombre: email, rol };
}

function logout() {
    cerrarSesionApi();
}

function requireLogin() {
    requireApiLogin();
}

function openModal(id) {
    const modal = document.getElementById(id);
    if (modal) modal.classList.add('show');
}

function closeModal(id) {
    const modal = document.getElementById(id);
    if (modal) modal.classList.remove('show');
}

function layout(title) {
    const linkAdmin = esAdmin()
        ? `<a href="carga.html"><span class="nav-ico">⚙️</span><span>Carga y Admin</span></a>`
        : '';

    return `
    <aside class="sidebar">
        <div class="brand">
            <img src="img/logo.jpg" alt="Bike Shop & Service">
            <div class="brand-copy">
                <strong>BIKE SHOP<br>& SERVICE</strong>
                <small>Sistema de gestión</small>
            </div>
        </div>
        <nav class="nav">
            <a href="menu.html"><span class="nav-ico">🏠</span><span>Inicio</span></a>
            <a href="taller.html"><span class="nav-ico">🔧</span><span>Taller y Órdenes</span></a>
            <a href="clientes.html"><span class="nav-ico">👥</span><span>Clientes</span></a>
            <a href="productos.html"><span class="nav-ico">📦</span><span>Repuestos</span></a>
            ${linkAdmin}
        </nav>
        <div class="logout">
            <a href="#" data-logout><span class="nav-ico">🚪</span><span>Cerrar sesión</span></a>
        </div>
    </aside>
    <main class="main">
        <header class="topbar">
            <div style="display:flex;align-items:center;gap:10px">
                <button class="mobile-toggle" aria-label="Abrir o contraer menú">☰</button>
                <h1 data-title>${esc(title)}</h1>
            </div>
            <div class="user" data-user></div>
        </header>
        <section class="content">`;
}

function endLayout() {
    return `</section></main>`;
}

function setupLayout(title) {
    requireLogin();
    const u = currentUser();
    document.title = `${title} | Bike Shop & Service`;

    document.querySelectorAll('[data-title]').forEach(el => {
        el.textContent = title;
    });

    const userEl = document.querySelector('[data-user]');
    if (userEl) {
        userEl.innerHTML = `
            <span class="avatar">${esc(u.nombre.charAt(0).toUpperCase())}</span>
            <span>
                ${esc(u.nombre)}<br>
                <small>${esc(u.rol)}</small>
            </span>`;
    }

    const paginaActiva = window.location.pathname.split('/').pop() || 'menu.html';
    document.querySelectorAll('.nav a').forEach(link => {
        if (link.getAttribute('href') === paginaActiva) {
            link.classList.add('active');
        }
    });

    document.querySelectorAll('[data-logout]').forEach(btn => {
        btn.onclick = logout;
    });

    const toggleBtn = document.querySelector('.mobile-toggle');
    const sidebar = document.querySelector('.sidebar');

    if (toggleBtn && sidebar) {
        toggleBtn.onclick = () => {
            if (window.innerWidth <= 760) {
                sidebar.classList.toggle('open');
            } else {
                document.body.classList.toggle('sidebar-collapsed');
                localStorage.setItem(
                    'bikeSidebarCollapsed',
                    document.body.classList.contains('sidebar-collapsed')
                );
            }
        };
    }

    if (window.innerWidth > 760 && localStorage.getItem('bikeSidebarCollapsed') === 'true') {
        document.body.classList.add('sidebar-collapsed');
    }
}

function renderLayout(title) {
    document.write(layout(title));
    setupLayout(title);
}