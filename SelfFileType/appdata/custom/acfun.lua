function Description()
    return
        'AcFun弹幕视频网- 认真你就输啦(・ω・)ノ- ( ゜- ゜)つロ';
end

function ExtensionName() return '.acfun'; end

function Icon() return 'acfun.ico'; end

function Urls() return {'acfun.cn'}; end

function FileName(url)
    local name = "acfun";
    url = url .. "/";
    local start = string.find( url, "/v/");
    if start ~= nail then
        name = string.match(url, "/v/(.-)/");
        name = name .. '.video';
    end
    start = string.find( url, "/a/" );
    if start ~= nail then
        name = string.match(url, "/a/(.-)/");
        name = name .. '.article';
    end
    start = string.find( url, "/u/" );
    if start ~= nail then
        name = string.match(url, "/u/(.-)/");
        name = name .. '.user';
    end
    start = string.find( url, "/live/" );
    if start ~= nail then
        name = string.match(url, "/live/(.-)/");
        name = name .. '.live';
    end
    start = string.find( url, "/search/" );
    if start ~= nail then
        name = string.match(url, "/search/.+keyword=(.+)/");
        name = name .. '.search';
    end
    return name;
end


local url_article = 'https://www.acfun.cn/a/ac36069854';
local url_video = 'https://www.acfun.cn/v/ac30946317';
local url_user = 'https://www.acfun.cn/u/13215999';
local url_live = 'https://live.acfun.cn/live/23512715';
local url_search = 'https://www.acfun.cn/search/?type=complex&keyword=%E8%BE%A3%E6%A4%92';
print(FileName(url_article))
print(FileName(url_video))
print(FileName(url_user))
print(FileName(url_live))
print(FileName(url_search))
