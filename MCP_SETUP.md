# MCP Setup — JogoMobile

> Documento de configuração dos servidores **MCP (Model Context Protocol)** usados neste
> projeto. Escrito para que outra IA (Claude Code, ou outro cliente MCP) entenda o que
> existe, **onde está** e **como reconfigurar** do zero.

---

## Visão geral

Este projeto usa **2 servidores MCP**:

| Servidor | Para quê | Onde é configurado | Versionado no git? |
|---|---|---|---|
| **unityMCP** (MCP For Unity, da CoplayDev) | Controlar o Unity Editor (GameObjects, scripts, cenas, testes) | `Packages/manifest.json` (pacote Unity) | ✅ Sim (é dependência) |
| **github** | Acessar PRs, issues, repos do GitHub | `.mcp.json` na raiz | ❌ **Não** (está no `.gitignore`) |

⚠️ **Importante:** o arquivo **`.mcp.json` NÃO é commitado** (entrou no `.gitignore`).
Quem clonar o repo **não recebe** esse arquivo — precisa recriá-lo seguindo este guia.

---

## 1. Unity MCP (`unityMCP`)

### Onde está
- Instalado como pacote Unity via git URL em [`Packages/manifest.json`](Packages/manifest.json):

```json
"com.coplaydev.unity-mcp": "https://github.com/CoplayDev/unity-mcp.git?path=/MCPForUnity#beta"
```

- Repositório: https://github.com/CoplayDev/unity-mcp/tree/beta/MCPForUnity

### Como configurar do zero
1. No Unity: **Window → Package Manager → + → Add package from git URL** e colar a URL acima
   (ou já vem resolvido ao abrir o projeto, pois está no `manifest.json`).
2. Abrir a janela **Window → MCP For Unity**.
3. Clicar em **Auto-Setup** — registra o cliente (Claude Code) e garante o bridge.
4. Se pedir, instalar dependências: **Python 3.10+** e **uv/uvx**. Para Claude Code, ter o `claude` CLI instalado.
5. Se o bridge estiver "Stopped", clicar **Start Bridge**.

### Requisitos
- Unity **2021.3 LTS até 6.x** (este projeto: 6000.3.x).
- Python 3.10+ (via `uv`).
- Git instalado (para o Package Manager baixar do GitHub).

### Como saber que funcionou
- A janela mostra o bridge **Running** e o cliente conectado.
- A IA passa a ter ferramentas `unityMCP` disponíveis (ex.: `manage_scene`, `read_console`).
- Múltiplas instâncias do Unity abertas expõem portas diferentes (ex.: 6400); selecionar a
  instância certa por `Name@hash` ou número da porta.

---

## 2. GitHub MCP (`github`)

### Onde está
- Definido em **`.mcp.json`** na raiz do projeto (**não versionado** — recriar do modelo abaixo).

### Conteúdo do `.mcp.json` (modelo — recrie este arquivo)

```json
{
  "mcpServers": {
    "github": {
      "type": "http",
      "url": "https://api.githubcopilot.com/mcp/"
    }
  }
}
```

> Este é o servidor GitHub **remoto oficial**, que usa **login OAuth** (não precisa de token
> em texto no arquivo — por isso é seguro, mas mesmo assim mantemos fora do git).

### Como configurar do zero
1. Criar o arquivo `.mcp.json` na raiz com o conteúdo acima.
   - Via CLI equivalente: `claude mcp add --scope project --transport http github https://api.githubcopilot.com/mcp/`
2. **Reiniciar o Claude Code** (servers do `.mcp.json` só carregam ao iniciar).
3. Aprovar o server quando o Claude Code perguntar se confia neste `.mcp.json`.
4. **Autenticar:** rodar `/mcp` numa sessão interativa → selecionar **github** → **Authenticate/Login**
   → o navegador abre para login OAuth no GitHub.
5. Verificar com `claude mcp list` (deve aparecer `github` conectado).

### Observações
- Enquanto não autenticar via OAuth, as ferramentas do GitHub ficam indisponíveis.
- Como o `.mcp.json` está no `.gitignore`, cada dev/IA recria localmente e autentica com a
  própria conta GitHub.

---

## 🔐 Regras de segurança

- **Nunca** colocar tokens/segredos em texto dentro do `.mcp.json`. Preferir OAuth (como acima).
- Se algum dia usar um MCP que exija token (PAT), passá-lo por **variável de ambiente**, nunca
  hardcoded, e manter o `.mcp.json` fora do git (já está).
- Não commitar `.mcp.json` — ele é config local por máquina/usuário.

---

## Resumo para outra IA

1. **Unity MCP:** já está no `manifest.json`. Abrir Unity → `Window → MCP For Unity` → Auto-Setup.
2. **GitHub MCP:** recriar `.mcp.json` (modelo acima, está gitignored) → reiniciar Claude Code →
   `/mcp` → autenticar OAuth.
3. Ambos prontos = ferramentas `unityMCP` e `github` disponíveis na sessão.
