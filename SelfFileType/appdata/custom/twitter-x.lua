function Description()
    return
        'Twitter X 從突發新聞到娛樂、體育和政治新聞，一手掌握完整消息和所有實況報導。';
end

function ExtensionName() return '.twitter-x'; end

function Icon() return 'twitter-x.ico'; end

function Urls() return {'x.com'}; end

function FileName(url)
    local defaultHost = "x.com";
    local defaultName = "Twitter-X";
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
    start = string.find( url, "/status/" );
    if start ~= nil then
        name = string.match(url, "/status/(.+)");
        name = urlDecode(name);
        name = name .. '.status';
        name = string.gsub(name, "/.", ".");
    end

    start = string.find( url, "/hashtag/" );
    if start ~= nil then
        name = string.match(url, "/hashtag/(.+)");
        name = urlDecode(name);
        name = name .. '.hashtag';
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


-- local url1 = 'https://x.com/mujitax';
-- local url2 = 'https://x.com/MujitaX/status/1789309492414329198';
-- local url3 = 'https://x.com/hashtag/nsfw?src=hashtag_click';
-- print(FileName(url1))
-- print(FileName(url2))
-- print(FileName(url3))
