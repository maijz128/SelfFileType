function Description()
    return
        '网易云音乐是一款专注于发现与分享的音乐产品，依托专业音乐人、DJ、好友推荐及社交功能，为用户打造全新的音乐生活。';
end

function ExtensionName() return '.music163'; end

function Icon() return 'music163.ico'; end

function Urls() return {'music.163.com'}; end

function FileName(url)
    local name = "网易云音乐";
    -- name = url:gsub("https://music.163.com/", "");
	-- name = name:gsub("https://music.163.com/", "");
    -- name = name:gsub("/", ".");

    local start = string.find( url, "/artist");
    if start ~= nil then
        -- name = string.match(url, "/artist?id=(.-)");
        name = string.match(url, "id=(%d+)");
        name = name .. '.artist';
    end

    start = string.find( url, "/album");
    if start ~= nil then
        name = string.match(url, "id=(%d+)");
        name = name .. '.album';
    end

    start = string.find( url, "/playlist");
    if start ~= nil then
        name = string.match(url, "id=(%d+)");
        name = name .. '.playlist';
    end

    return name;
end


-- local url = 'https://music.163.com/#/artist?id=8304';
-- local album = 'https://music.163.com/#/album?id=25365';
-- local playlist = 'https://music.163.com/#/playlist?id=8181731946';
-- print(FileName(url))
-- print(FileName(album))
-- print(FileName(playlist))


