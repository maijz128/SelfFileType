function Description()
    return
        '豆瓣 - 提供图书、电影、音乐唱片的推荐、评论和价格比较，以及城市独特的文化生活。';
end

function ExtensionName() return '.douban'; end

function Icon() return 'douban.ico'; end

function Urls() return {'douban.com'}; end

function FileName(url)
    local name = "豆瓣";
    url = url .. "/";
    local start = string.find( url, "movie.douban.com/subject/");
    if start ~= nil then
        name = string.match(url, "/subject/(.-)/");
        name = name .. '.movie';
    end
    start = string.find( url, "movie.douban.com/celebrity/" );
    if start ~= nil then
        name = string.match(url, "/celebrity/(.-)/");
        name = name .. '.celebrity';
    end
    return name;
end


local url_movie = 'https://movie.douban.com/subject/1292213';
print(FileName(url_movie))
