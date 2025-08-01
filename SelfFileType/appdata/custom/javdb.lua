function Description()
    return
        'JavDB 成人影片資料庫及磁鏈分享';
end

function ExtensionName() return '.javdb'; end

function Icon() return 'javdb.ico'; end

function Urls() return {'javdb.com'}; end

function FileName(url)
    local name = "JavDB";
    name = url:gsub("https://javdb.com/", "");
    name = name:gsub("/", ".");
    name = name:gsub("?", "#");
    return name;
end




function FileName2(url)
    local defaultHost = "javdb.com";
    local defaultName = "JavDB";
    local name = defaultName;
    url = string.gsub(url, "https://", "");
    url = string.gsub(url, "http://", "");
    url = url .. "/";
    url = string.gsub(url, "//", "/");

    local start = '';
    start = string.find( url, "/(.+)/" );
    if start ~= nil then
        name = string.match(url, "/(.+)/");
        -- name = name .. '.user';
        name = string.gsub(name, "/.", ".");
    end
    start = string.find( url, "/v/" );
    if start ~= nil then
        name = string.match(url, "/v/(.+)");
        name = urlDecode(name);
        name = 'v.' .. name;
        name = string.gsub(name, "/.", ".");
    end

    start = string.find( url, "/publishers/" );
    if start ~= nil then
        name = string.match(url, "/publishers/(.+)");
        name = urlDecode(name);
        name = 'publishers.' .. name;
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


-- local url1 = 'https://javdb.com/v/YwykB';
-- local url2 = 'https://javdb.com/publishers/45NZ?f=download';
-- local url3 = 'https://x.com/hashtag/nsfw?src=hashtag_click';
-- print(FileName(url1))
-- print(FileName(url2))
-- print(FileName(url3))

