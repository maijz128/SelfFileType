function Description()
    return
        'F95zone | Adult Games | Comics | Mods | Cheats.';
end

function ExtensionName() return '.f95zone'; end

function Icon() return 'f95zone.ico'; end

function Urls() return {'f95zone.to'}; end

function FileName(url)
    local name = "F95zone";
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");


    local start = '';
    start = string.find( url, "/threads/" );
    if start ~= nil then
        name = string.match(url, "/threads/(.+)/");
        name = name .. '.thread';
    end
    start = string.find( url, "/tags/" );
    if start ~= nil then
        name = string.match(url, "/tags/(.+)/");
        name = name .. '.tag';
    end
    start = string.find( url, "/forums/" );
    if start ~= nil then
        name = string.match(url, "/forums/(.+)/");
        name = name .. '.forum';
    end

    if name == "F95zone" then
        name = url;
        name = string.gsub(name, "www.f95zone.to/", "");
        name = string.gsub(name, "f95zone.to/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
    end


    return name;
end


local url_1 = 'https://f95zone.to/threads/hydrafxx-collection-2024-01-01-hydrafxx.25063/';
local url_2 = 'https://f95zone.to/forums/animations-loops.94/';
local url_3 = 'https://f95zone.to/tags/3dcg/';
local url_4 = 'https://f95zone.to/tags/3dcg';
print(FileName(url_1))
print(FileName(url_2))
print(FileName(url_3))
print(FileName(url_4))
