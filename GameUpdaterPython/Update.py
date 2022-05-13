import git
repo = git.Repo('./GameFiles/Portfolio')
repo.remotes.origin.pull()