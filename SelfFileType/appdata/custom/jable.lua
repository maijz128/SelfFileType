function Description()
    return
        'Jable.TV | 免費高清AV在線看 | J片 AV看到飽';
end

function ExtensionName() return '.jable'; end

function Icon() return 'jable.ico'; end

function Urls() return {'jable.tv'}; end

function FileName(url)
    local name = "jable";
    url = url .. "/";
    local vstart, vend = string.find( url, "/videos/");
    if vstart ~= nil then
        name = string.match(url, "/videos/(.-)/");
        name = name .. '.video';
    end
    local mstart, mend = string.find( url, "/models/" );
    if mstart ~= nil then
        name = string.match(url, "/models/(.-)/");
        name = name .. '.model';
    end
    return name;
end

local url = 'https://jable.tv/videos/cjod-363/';
local url_model = 'https://jable.tv/models/99df40f2a110f8540246b0b975b1ccc7/';
print(string.match(url, "/videos/(.-)/"))
print(FileName(url))
print(FileName(url_model))
