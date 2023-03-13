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
	start = string.find( url, "/gallery/" );
    if start ~= nil then
        name = string.match(url, "/gallery/(.*)");
		name = name:gsub("?.*", "");
        name = name .. '.gallery';
    end
    return name;
end


-- local url_article = 'https://civitai.com/models/11367/tifameenow';
-- local url_user = 'https://civitai.com/user/Meenow';
-- local url_gallery = 'https://civitai.com/gallery/203407?modelId=8281&modelVersionId=19084&infinite=false&returnUrl=%2Fmodels%2F8281%2Fperfect-world';
-- local url_gallery = 'https://civitai.com/gallery/203407?modelId=8281&modelVersionId=19084&infinite=false&returnUrl=完美世界perfect-world';
-- print(FileName(url_article))
-- print(FileName(url_user))
-- print(FileName(url_gallery))

