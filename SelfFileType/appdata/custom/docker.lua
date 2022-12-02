function Description()
    return
        'Docker 是一个开源的应用容器引擎，基于 Go 语言 并遵从 Apache2.0 协议开源。';
end

function ExtensionName() return '.docker'; end

function Icon() return 'docker.ico'; end

function Urls() return {'docker.com'}; end

function FileName(url)
    local name = "docker";
    local urlEx = url .. "/";
    local start1 = string.find(urlEx, "/_/");
    if start1 ~= nil then
        name = string.match(urlEx, "/_/(.-)/");
        name = name .. '.Image';
    end
    local start2 = string.find(urlEx, "/r/");
    if start2 ~= nil then
        name = string.match(urlEx, "/r/.+/(.-)/");
        name = name .. '.Image';
    end
    local start3 = string.find(urlEx, "/u/");
    if start3 ~= nil then
        name = string.match(urlEx, "/u/(.-)/");
        name = name .. '.User';
    end
    local startT = string.find(urlEx, "forums.docker.com/t/");
    if startT ~= nil then
        name = string.match(urlEx, "forums.docker.com/t/(.-)/");
        name = name .. '.Forums';
    end
    return name;
end

local url_official_image = 'https://hub.docker.com/_/nextcloud';
local url_user_image = 'https://hub.docker.com/r/linuxserver/qbittorrent';
local url_user = 'https://hub.docker.com/u/linuxserver';
local url_thread = 'https://forums.docker.com/t/docker-is-damaged/128093';
print(string.match(url_official_image, "/_/(.-)"))
print(string.match(url_user_image, "/r/.+/(.-)"))
print(FileName(url_official_image))
print(FileName(url_user_image))
print(FileName(url_user))
print(FileName(url_thread))

