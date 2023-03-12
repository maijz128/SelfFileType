function Description()
    return
        'Civitai';
end

function ExtensionName() return '.civitai'; end

function Icon() return 'civitai.ico'; end

function Urls() return {'civitai.com'}; end

function FileName(url)
    local name = "Civitai";
    url = url .. "/";
    local start = string.find( url, "/models/");
    if start ~= nil then
        name = string.match(url, "/models/(.-)/");
        name = name .. '.models';
    end
    start = string.find( url, "/user/" );
    if start ~= nil then
        name = string.match(url, "/user/(.-)/");
        name = name .. '.user';
    end
    return name;
end


local url_article = 'https://civitai.com/models/11367/tifameenow';
local url_user = 'https://civitai.com/user/Meenow';
print(FileName(url_article))
print(FileName(url_user))
