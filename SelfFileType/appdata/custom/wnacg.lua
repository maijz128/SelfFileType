function Description()
    return
        '紳士漫畫-專註分享漢化本子';
end

function ExtensionName() return '.wnacg'; end

function Icon() return 'wnacg.ico'; end

function Urls() return {'wnacg.com'}; end

function FileName(url)
    local defaultHost = "wnacg.com";
    local defaultName = "WNACG";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/photos%-index%-aid%-" );
    if start ~= nil then
        name = string.match(url, "/photos%-index%-aid%-(.+)%.html");
        name = name .. '.photos';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/albums%-index%-tag%-" );
    if start ~= nil then
        name = string.match(url, "/albums%-index%-tag%-(.+)%.html");
        name = urlDecode(name);
        name = name .. '.tag';
        name = string.gsub(name, "/.", ".");
    end


    if name == defaultName then
        name = url;
        name = string.gsub(name, "www." .. defaultHost .. "/", "");
        name = string.gsub(name, defaultHost .. "/", "");
        name = string.gsub(name .. "/", "//", "");
        name = string.gsub(name, "/", ".");
    end

    return name;
end

function urlDecode(s)  
    s = string.gsub(s, '%%(%x%x)', function(h) return string.char(tonumber(h, 16)) end)  
    return s  
end  


-- local url1 = 'https://www.wnacg.com/photos-index-aid-239671.html';
-- local url2 = 'https://www.wnacg.com/albums-index-tag-%E5%B7%A8%E4%B9%B3.html';
-- print(FileName(url1))
-- print(FileName(url2))
-- print(urlDecode(url2))
