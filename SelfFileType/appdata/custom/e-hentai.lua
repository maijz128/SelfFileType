function Description()
    return
        'E-Hentai，又稱E站、E紳士、熊貓網，是一個非營利性質的網路圖片分享網站';
end

function ExtensionName() return '.e-hentai'; end

function Icon() return 'e-hentai.ico'; end

function Urls() return {'e-hentai.org', 'exhentai.org'}; end

function FileName(url)
    local name = "E-Hentai";

    local isExhentai = string.find( url, "exhentai.org");
    if isExhentai ~= nil then
        name = 'ExHentai';
    end

    local urlpath = url:gsub("https://exhentai.org/", "");
	urlpath = urlpath:gsub("https://e-hentai.org/", "");
    name = urlpath:gsub("/", ".");

    local start = string.find( url, "/g/");
    if start ~= nil then
        name = string.match(url, "/g/(%S+)");
        name = name:gsub("/", ".");
        name = name .. '.g';
        name = name:gsub("..g", ".g");
    end

    start = string.find( url, "/tag/");
    if start ~= nil then
        name = string.match(url, "/tag/(%S+)");
        name = name:gsub(":", "=");
        name = name .. '.tag';
    end

    start = string.find( url, "/?f_search=");
    if start ~= nil then
        name = string.match(url, "/?f_search=(%S+)");
        name = name:gsub("%%3A", "=");
        name = name:gsub("%%24", "$");
        name = name .. '.search';
    end

    start = string.find( url, "/uploader/");
    if start ~= nil then
        name = string.match(url, "/uploader/(%S+)");
        name = name .. '.uploader';
    end

    return name;
end


-- local url = 'https://exhentai.org/g/2290290/4e82a51f70/';
-- local tag = 'https://exhentai.org/tag/female:netorare';
-- local search = 'https://exhentai.org/?f_search=l%3Achinese%24+f%3Amilf%24+f%3Amilking%24+';
-- local uploader = 'https://exhentai.org/uploader/alfredmeow';
-- print(FileName(url))
-- print(FileName(tag))
-- print(FileName(search))
-- print(FileName(uploader))
-- print(ExtensionName())


